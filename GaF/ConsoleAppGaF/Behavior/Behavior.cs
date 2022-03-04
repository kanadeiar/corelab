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

        Console.WriteLine("Iterator");
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

        Console.WriteLine("Mediator");
        Component1 component1 = new Component1();
        new ConcreteMediator(component1);
        Console.WriteLine("Client triggets operation A.");
        component1.DoA();
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Momento");
        var originator = new Originator("Super-duper-super-puper-super.");
        var caretaker = new Caretaker(originator);
        caretaker.Backup();
        originator.DoSomething();
        caretaker.Backup();
        originator.DoSomething();
        Console.WriteLine();
        caretaker.ShowHistory();
        caretaker.Undo();
        caretaker.Undo();
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Observer");
        var subject = new Subject();
        var observerA = new ConcreteObserverA();
        subject.Attach(observerA);
        subject.SomeBisinessLogic();
        subject.SomeBisinessLogic();
        subject.Detach(observerA);
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("State");
        var context = new Context(new ConcreteStateA());
        context.Request1();
        context.Request1();
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Strategy");
        var context = new Strategy.Context();
        context.SetStrategy(new Strategy.ConcreteStrategyA());
        context.DoSomeBusinessLogic();
        context.SetStrategy(new Strategy.ConcreteStrategyB());
        context.DoSomeBusinessLogic();
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Template method");
        AbstractClass concrete1 = new ConcreteClass1();
        concrete1.TemplateMethod();
        AbstractClass concrete2 = new ConcreteClass2();
        concrete2.TemplateMethod();
        Console.WriteLine();
        Console.ReadKey();

        Console.WriteLine("Visitor");
        IComponent component = new ConcreteComponentA();
        Console.WriteLine("visit to the base visitor interface");
        var visitor = new ConcreteVisitor();
        component.Accept(visitor);
        Console.WriteLine();
        Console.ReadKey();


    }
}
