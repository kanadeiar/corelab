using Kanadeiar.Core.Async;

namespace SimpleConsole;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Начало программы");



        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }
}











