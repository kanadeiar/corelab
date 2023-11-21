using ConsoleApp1.File;

namespace ConsoleApp1;

static class Program
{
    public static void Main(string[] args)
    {
        //await new Database().Execute();

        var repo = new WorkersRepository();
        var all = repo.All().ToArray();

        Console.WriteLine("Работкики:");
        foreach (var worker in all)
        {
            Console.WriteLine($"{worker.Id} {worker.Name} {worker.Birthday}");
        }

        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();
    }
}

