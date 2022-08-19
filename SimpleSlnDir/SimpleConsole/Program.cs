using System.Reflection;
using System.Text;
using Kanadeiar.Core.Async;

namespace SimpleConsole;

internal partial class Program
{

    private static async Task Main(string[] args)
    {
        // 801
        // var val = await Task.Run(() => Simple.Method(1));
        // Console.WriteLine($"value = {val}");

#if DEBUG
        // Использование TaskLogger приводит к лишним затратам памяти
        // и снижению производительности; включить для отладочной версии
        TaskLogger.LogLevel = TaskLogger.TaskLogLevel.Pending;
#endif
        System.Console.WriteLine("Начало первой части");
        var tasks = new List<Task>
        {
            Task.Delay(2_000).Log("2с"),
            Task.Delay(4_000).Log("4с"),
            Task.Delay(6_000).Log("6с"),
        };

        try
        {
            await Task.WhenAll(tasks).WithCancellation(new CancellationTokenSource(3_000).Token);
        }
        catch (OperationCanceledException)
        {
        }

        var logs = TaskLogger.GetLogStrings().ToArray();
        Array.ForEach(logs, Console.WriteLine);




        var cts = new CancellationTokenSource(1_000);
        var token = cts.Token;
        try
        {
            await Task.Delay(10_000).WithCancellation(token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Операция отменена");
        }

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }
}


