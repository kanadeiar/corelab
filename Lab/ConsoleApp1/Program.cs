
using ConsoleApp1.Shared;

namespace ConsoleApp1;

public static class Program
{
    public static void Main(string[] args)
    {
        var test = new Test();

        test.Message();


        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();
    }
}

