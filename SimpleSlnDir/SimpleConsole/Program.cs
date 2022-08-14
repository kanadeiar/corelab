using System.Reflection;

namespace SimpleConsole;





internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Test");
        var s = new Sample();
        var result = Task.Run(() => s.Method(5)).Result;
        Console.WriteLine(result);

        Console.WriteLine("Нажмите любую кнопку ...");
        Console.ReadKey();
    }

}

class Sample
{
    public async Task<int> Method(int value)
    {
        int foo = value * 2;
        await Task.Delay(1000);
        return foo;
    }
}

