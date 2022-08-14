using System.Reflection;

namespace SimpleConsole;





internal class Program
{
    private static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(Method, 5);
        new Task(Method, 5).Start();
        Task.Run(() => Method(5));

        Console.WriteLine("Любую кнопку нажать для отмены");
        Console.ReadKey();
        
        
        
        Console.WriteLine("Нажмите любую кнопку ...");
        Console.ReadKey();
    }


    static void Method(object? state)
    {
        Console.WriteLine("Готово !");
    }
}


