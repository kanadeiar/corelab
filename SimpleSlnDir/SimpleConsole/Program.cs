namespace SimpleConsole;





internal class Program
{
    private static void Main(string[] args)
    {
        var list = new List<int>();
        list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        var numbers = list.FindAll(static i => (i % 2) == 0);
        foreach (var e in numbers)
        {
            Console.Write(e + "");
        }

        ThreadPool.QueueUserWorkItem(delegate (object? obj) { Console.WriteLine(obj); }, 5);


        //var value = 10;
        //var simple = new Simple();
        //simple.Sample1 += static delegate(object? _, SimpleEventArgs e) 
        //{
        //    //value = 20; //теперь нельзя так делать
        //    Console.WriteLine("Вызов: " + e?.Message);
        //};
        //simple.Simulate();

        Console.WriteLine("Нажмите любую кнопку ...");
        Console.ReadKey();
    }
}

class Simple
{
    public event EventHandler<SimpleEventArgs>? Sample1;
    protected virtual void OnNewValue(SimpleEventArgs e)
    {
        if (Volatile.Read(ref Sample1) is { } temp)
        {
            temp(this, e);
        }
    }
    public void Simulate()
    {
        OnNewValue(new SimpleEventArgs("New Value"));
    }
}

class SimpleEventArgs : EventArgs
{
    public string Message { get; set; }
    public SimpleEventArgs(string message)
    {
        Message = message;
    }
}