using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using Kanadeiar.Core.Tools;

namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        string s1 = "Hello";
        string s2 = "Hello";
        Console.WriteLine(object.ReferenceEquals(s1, s2));

        Console.WriteLine("Нажмите любую кнопку ...");
        Console.ReadKey();
    }
}












