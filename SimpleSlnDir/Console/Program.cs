using System.Numerics;

Console.WriteLine("Console application");

for (byte i = 0; i <= 10; i++)
{
    Console.WriteLine($"{i} - {(Sample.IsSimple(i) ? "Простое" : "Сложное")}");
}

Console.WriteLine("Press any key...");
var _ = Console.ReadKey();

public static class Sample
{
    public static T Add<T>(T one, T two) where T : INumber<T>
    {
        return one * two;
    }
    public static bool IsSimple<T>(T n) where T : IBinaryInteger<T>
    {
        var k = (T)Convert.ChangeType(2, typeof(T));
        while (k * k <= n && n % k != default(T))
        {
            k++;
        }
        return (k * k > n);
    }
}