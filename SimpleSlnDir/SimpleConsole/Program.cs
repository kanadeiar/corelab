using System;

namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        Calc c = new Calc();
        int ans = c.Add(1, 2);
        Console.WriteLine("1 + 2 = {0}", ans.ToString());
        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }
}

class Calc
{
    public int Add(int one, int two)
    {
        return one + two;
    }
}