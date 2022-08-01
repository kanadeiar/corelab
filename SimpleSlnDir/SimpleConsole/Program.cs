using System;

namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        var z = Test(1, 2, 3);


        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }
    static int Test(params int[] values)
    {
        int sum = 0;
        if (values != null)
        {
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
        }
        return sum;
    }
}

