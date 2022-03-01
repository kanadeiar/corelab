namespace ConsoleAppGaF.Struct;

public static class Struct
{
    public static void Invoke()
    {
        Console.WriteLine("Adapter");
        var target = new Adapter(new Adaptee());
        Console.WriteLine($"My adapter: {target.GetMyRequest()}");        
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Bridge");
        var abstraction = new Abstraction(new ConcreteImplementationA());
        Console.Write(abstraction.Operation());
        var abstractionExt = new ExtendedAbstaction(new ConcreteImplementationA());
        Console.Write(abstractionExt.Operation());
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Composite");
        Leaf leaf = new Leaf();
        Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        Composite tree = new Composite();
        Composite branch1 = new Composite();
        branch1.Add(new Leaf());
        branch1.Add(new Leaf());
        Composite branch2 = new Composite();
        branch2.Add(new Leaf());
        tree.Add(branch1);
        tree.Add(branch2);
        Console.WriteLine($"RESULT: {tree.Operation()}\n");
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Decoreator");
        var simple = new ConcreteComponent();
        Console.WriteLine("RESULT: " + simple.Operation());
        var decorator1 = new ConcreteDecoratorA(simple);
        Console.WriteLine("RESULT: " + decorator1.Operation());
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Facade");
        Subsystem1 subsystem1 = new Subsystem1();
        Facade facade = new Facade(subsystem1);
        Console.Write(facade.Operation());
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Flyweight");
        var factory = new FlyweightFactory(
            new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
            new Car { Company = "MercedesBenz", Model = "C300", Color = "black" }
        );
        factory.listFlyweights();

        Console.WriteLine();
        Console.ReadKey();
    }
}
