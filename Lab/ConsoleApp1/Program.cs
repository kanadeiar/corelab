using ConsoleApp1.Primes;

namespace ConsoleApp1;

public static class Program
{
    public static void Main(string[] args)
    {
        var printer = new PrimePrinter();
        printer.PrintPrimes();

        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();
    }
}

