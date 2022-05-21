using System.Diagnostics.Contracts;

public sealed partial class Program {
    public static void Main()
    {
        var val = Sum(1, -1);
        Console.WriteLine(val);
        Console.WriteLine("Hello, World!");
        Console.ReadKey(true);
    }

    static int Sum(int a, int b)
    {
        Contract.Requires(a > 0, "Нужно чтоб а было больше нуля");
        Contract.Requires(b > 0, "Нужно чтоб b было больше нуля");
        
        var value = a + b;
        return value;
    }
}




