using Kanadeiar.Core.Async;

namespace SimpleConsole;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Начало программы");

        await foreach (var e in GetInts())
        {
            Console.WriteLine(e);
        }


        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }

    static async IAsyncEnumerable<int> GetInts()
    {
        for (var i = 0; i < 10; i++)
        {
            await Task.Delay(100);
            yield return i;
        }
    }

    private static async ValueTask<int> GetValue(int value)
    {
        var result = value * 2;
        await Task.Delay(1000);
        return result;
    }
}











