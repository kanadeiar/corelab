namespace ConsoleAppGaF.Behavior;

public class Behavior
{
    public static void Invoke()
    {
        Console.WriteLine("GoF Behavior");
        Console.WriteLine("Chain");
        var monkey = new MonkeyHandler();
        var dog = new DogHandler();
        monkey.SetNext(dog);
        Console.WriteLine("Chain: Monkey -> Dog");
        Console.WriteLine(monkey.Handle("Meat"));
        Console.WriteLine("Chain: Monkey");
        Console.WriteLine(monkey.Handle("Banana"));
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Commands");
        var invoker = new Invoker();
        invoker.SetOnStart(new SimpleCommand("Say Hi!"));
        invoker.SetOnStop(new SimpleCommand("Say Bye!"));
        invoker.Invoke();
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Collection");
        var collection = new WordsCollection();
        collection.Add("First");
        collection.Add("Second");
        collection.Add("Third");
        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine("\nReverse:");
        collection.ReverseDirection();
        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine();
        Console.ReadKey();


    }
}
