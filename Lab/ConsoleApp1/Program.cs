using ConsoleApp1.Class;

namespace ConsoleApp1;

static class Program
{
    public static void Main(string[] args)
    {
        var primePrinter = new PrimePrinter();
        primePrinter.PrintPrimes();


        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();
    }
}

