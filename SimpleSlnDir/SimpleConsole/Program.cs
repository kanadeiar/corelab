using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Kanadeiar.Core.Enums;

namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        Actions actions = Actions.Delete | Actions.Read;
        Console.WriteLine(actions);
        Console.WriteLine(actions.ToString("F"));
        var a = (Actions)Enum.Parse(typeof(Actions), "query", true);
        Console.WriteLine(a.ToString());
        Enum.TryParse(typeof(Actions), "query, read", true, out var a2);
        Console.WriteLine(a2?.ToString());
        var a3 = Enum.Parse(typeof(Actions), "28");
        Console.WriteLine(a3.ToString());


        var bb = actions.IsSet(Actions.Read);
        actions = actions.Set(Actions.Sync);
        actions = actions.Clear(Actions.Read);
        actions.ForEach(x => Console.WriteLine(x));

        Console.WriteLine("Нажмите любую кнопку ...");
        Console.ReadKey();
    }
}

public static class Extensions
{
    public static bool IsSet(this Actions flags, Actions flagToTest)
    {
        if (flagToTest == 0)
            throw new ArgumentOutOfRangeException(nameof(flagToTest));
        return (flags & flagToTest) == flagToTest;
    }
    public static bool IsClear(this Actions flags, Actions flagToTest)
    {
        if (flagToTest == 0)
            throw new ArgumentOutOfRangeException(nameof(flagToTest));
        return !IsSet(flags, flagToTest);
    }
    public static bool AnyFlagsSet(this Actions flags, Actions testFlags)
    {
        return ((flags & testFlags) != 0);
    }
    public static Actions Set(this Actions flags, Actions setFlag)
    {
        return (flags | setFlag);
    }
    public static Actions Clear(this Actions flags, Actions clearFlags)
    {
        return (flags | ~clearFlags);
    }
    public static void ForEach(this Actions flags, Action<Actions> processFlag)
    {
        if (processFlag == null)
            throw new ArgumentNullException(nameof(processFlag));
        for (uint bit = 1; bit != 0; bit <<= 1)
        {
            uint temp = ((uint)flags) & bit;
            if (temp != 0)
            {
                processFlag.Invoke((Actions)temp);
            }
        }
    }
}

[Flags]
public enum Actions
{
    None = 0,
    Read = 0x0001,
    Write = 0x0002,
    ReadWrite = Actions.Read | Actions.Write,
    Delete = 0x0004,
    Query = 0x0008,
    Sync = 0x0010
}

enum Color
{
    Black,
    White,
    Red,
}












