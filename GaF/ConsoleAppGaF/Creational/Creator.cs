namespace ConsoleAppGaF.Creational;

public static class Creator
{
    public static void Invoke()
    {
        Console.WriteLine("GoF Creator");
        Console.WriteLine("Client: Testing client code with the factory type...");
        ClientMethod(new ConcreteFactory1());
        Console.WriteLine();
        Console.ReadKey();

        void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            Console.WriteLine(productA.UsefulFunctionA());
        }
        /////////////////////////////////////////////

        Console.WriteLine("GoF Builder");
        Console.WriteLine("Testing builder");
        var director = new Direcrtor();
        var builder = new ConcreteBuilder();
        director.Builder = builder;

        Console.WriteLine("Basic");
        director.BuildMinimal();
        foreach (var e in builder.Get().Parts)
            Console.WriteLine("- " + e);
        Console.WriteLine("Maximum");
        director.BuildMaximum();
        foreach (var e in builder.Get().Parts)
            Console.WriteLine("- " + e);
        Console.WriteLine();
        Console.ReadKey();

        /////////////////////////////////////////////
        Console.WriteLine("GoF Builder");
        Console.WriteLine("Testing FacrotyMethods");

        ClientCode(new ConcreteCreator1());

        void ClientCode(ICreator creator)
        {
            Console.WriteLine($"Client: {creator.SomeOperation()}");
        }
        Console.WriteLine();
        Console.ReadKey();

        /////////////////////////////////////////////
        Console.WriteLine("GoF Builder");
        Console.WriteLine("Testing Prototype");

        var p1 = new Person { Name = "Test" };

        var p2 = p1.ShallowCopy();
        var p3 = p1.Copy();
        Console.WriteLine();
        Console.ReadKey();

        /////////////////////////////////////////////
        Console.WriteLine("GoF Builder");
        Console.WriteLine("Testing SIngleton");

        var s1 = Singleton.GetInstance();
        var s2 = Singleton.GetInstance();
        if (s1 == s2)
        {
            Console.WriteLine("Equals");
        }
        Console.WriteLine();
        Console.ReadKey();

    }
}
