using System.Reflection;
using System.Text;

namespace SimpleConsole;






internal class Program
{
    private static void Main(string[] args)
    {
        var names = new string[] { "Паша", "Петя", "Соня" };
        int total = 0;
        var result = Parallel.ForEach<string, int>(
            names,
        () =>
        {
            return 0;
        },
        (name, loopState, index, taskLocalTotal) =>
        {
            var len = name.Length;
            return taskLocalTotal + len;

        },
        taskLocalTotal =>
        {
            Interlocked.Add(ref total, taskLocalTotal);
        });
        System.Console.WriteLine("Всего символов: {0}", total);



        // var collection = new List<int>();

        // Parallel.For(0, 1000, x => DoWork(x));
        // Parallel.ForEach(collection, x => DoWork(x));
        // Parallel.Invoke(() => DoWork(1), () => DoWork(2));

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }

    private static void DoWork(int i)
    {
        Console.WriteLine(i);
    }
}


