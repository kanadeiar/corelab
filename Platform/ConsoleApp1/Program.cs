internal delegate void Feedback(int value);

public sealed partial class Program {
    public static void Main()
    {
        StaticDelegate();
        InstanceDelegate();
        Console.WriteLine("- Chain");
        ChainDelegate(new Program());
        Console.WriteLine("Hello, World!");
        Console.ReadKey(true);
    }

    public static void StaticDelegate()
    {
        Counter(1, 3, null);
        Counter(1, 3, new Feedback(FeedbackToConsole));
        Console.WriteLine();
    }

    public static void InstanceDelegate()
    {
        var p = new Program();
        Counter(1, 3, new Feedback(p.FeedbackToInstance));
        Console.WriteLine();
    }

    public static void ChainDelegate(Program p)
    {
        var fb1 = new Feedback(FeedbackToConsole);
        var fb2 = new Feedback(Feedback2ToConsole);
        var fb3 = new Feedback(p.FeedbackToInstance);

        Feedback chain = null;
        chain += fb1;
        chain += fb2;
        chain += fb3;
        Counter(1, 3, chain);
        Console.WriteLine(Environment.NewLine + "- Rechain");
        chain -= new Feedback(FeedbackToConsole);
        chain -= new Feedback(Feedback2ToConsole);
        Counter(1, 3, chain);
    }

    static void Counter(int from, int to, Feedback fb)
    {
        for (int i = from; i < to; i++)
        {
            if (fb != null)
            {
                fb.Invoke(i);
            }
        }
    }

    static void FeedbackToConsole(int value)
    {
        Console.WriteLine("Item=" + value);
    }

    static void Feedback2ToConsole(int value)
    {
        Console.WriteLine("Item2=" + value);
    }

    void FeedbackToInstance(int value)
    {
        Console.WriteLine("ItemInst=" + value);
    }
}



