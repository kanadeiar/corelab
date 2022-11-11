using System.Diagnostics;
using System.Numerics;

Console.WriteLine("Console application");

var res = Sample.Add(10, 3.3);
Console.WriteLine(res);

Console.WriteLine("Press any key to end...");
var _ = Console.ReadKey();

public static class Sample
{
    public static T Add<T>(T one, T two) where T : INumber<T>
    {
        return one + two;
    }
}
