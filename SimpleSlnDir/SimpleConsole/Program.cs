using System.Reflection;
using System.Text;

namespace SimpleConsole;

internal partial class Program
{
    private static async void DelayTimer()
    {
        while (true)
        {
            Console.WriteLine("Срабатывание таймера: {0}", DateTime.Now);
            await Task.Delay(1000);
        }
    }

    //private static Timer _timer;
    private static void Main(string[] args)
    {
        // _timer = new Timer(Method, null, Timeout.Infinite, Timeout.Infinite);
        // _timer.Change(0, Timeout.Infinite);
        // static void Method(object? state)
        // {
        //     Console.WriteLine("Срабатывание таймера {0}", DateTime.Now);
        //     Thread.Sleep(100); //полезная работа
        //     _timer.Change(2000, Timeout.Infinite);
        // }
        // DelayTimer();


        // var names = new string[] { "test", "zero", "hero", "one", "three" };
        // var pquery = names.AsParallel(); // переход в параллельный режим
        // pquery = pquery.Select(x => $"Имя: {x}");
        // var count = 0;
        // pquery.ForAll(x => count += 1);
        // System.Console.WriteLine("Количество: {0} шт.", count);
        // var query = pquery.AsSequential().OrderBy(x => x); // переход обратно в последовательный режим
        // foreach (var e in query)
        // {
        //     Console.WriteLine(e);
        // }
        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }

}


