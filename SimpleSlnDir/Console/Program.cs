using System.Numerics;

Console.WriteLine("Console application");

var res = Sample.Add(1, 6);

Console.WriteLine(res);


Console.WriteLine("Press any key...");
var _ = Console.ReadKey();

public class Sample
{
    public static T Add<T>(T one, T two) where T : INumber<T>
    {
        return one * two;
    }
}