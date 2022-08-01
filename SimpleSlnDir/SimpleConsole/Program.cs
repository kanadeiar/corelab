using System;

namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        var dt = DateTime.Now;
        var test = new { dt.Year };
        Console.WriteLine($"Year = {test.Year}");

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }

}

