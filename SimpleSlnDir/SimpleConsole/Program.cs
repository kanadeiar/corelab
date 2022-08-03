using System;
using System.Collections;
using System.Diagnostics;
using Kanadeiar.Core.Tools;

namespace CalculatorExamples;

public delegate TReturn CallTest<out TReturn, in TValue>(TValue value);

internal class Program
{
    private static void Main(string[] args)
    {


        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }
}








