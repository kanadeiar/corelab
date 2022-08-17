using System.Reflection;
using System.Text;

namespace SimpleConsole;





internal class Program
{
    private static void Main(string[] args)
    {
        var names = new string[] { "test", "zero", "hero", "one", "three" };
        var pquery = names.AsParallel(); // переход в параллельный режим
        pquery = pquery.Select(x => $"Имя: {x}");
        var count = 0;
        pquery.ForAll(x => count += 1);
        System.Console.WriteLine("Количество: {0} шт.", count);
        var query = pquery.AsSequential().OrderBy(x => x); // переход обратно в последовательный режим
        foreach (var e in query)
        {
            Console.WriteLine(e);
        }



        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }
}


