using System;
using System.Diagnostics;
using Kanadeiar.Core.Tools;

namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        using (new OperationTimer("Test"))
        {
            var manager = new TestManager();
            manager.Message += Method;
            var fax = new Fax(manager);
            manager.SimulateNewMessage(1, 2);
            fax.Unregister(manager);
        }

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }
    private static void Method(Object? s, TestEventArgs e)
    {
        System.Console.WriteLine($"Value = {e.One} {e.Two}");
    }
}

//объект, заинтересованный в уведомлении о событии
internal sealed class Fax
{
    public Fax(TestManager tm)
    {
        tm.Message += FaxMessage;
    }
    private void FaxMessage(object? sender, TestEventArgs e)
    {
        System.Console.WriteLine($"Fax message: {e.One} {e.Two}");
    }
    public void Unregister(TestManager tm)
    {
        tm.Message -= FaxMessage;
    }
}



internal class TestEventArgs : EventArgs
{
    private readonly int _one;
    private readonly int _two;
    public TestEventArgs(int one, int two)
    {
        _one = one;
        _two = two;
    }
    public int One => _one;
    public int Two => _two;
}

internal class TestManager
{
    public event EventHandler<TestEventArgs> Message;
    public virtual void OnMessage(TestEventArgs e)
    {
        e.Raise(this, ref Message);
    }

    public void SimulateNewMessage(int one, int two)
    {
        OnMessage(new TestEventArgs(one, two));
    }
}

// internal sealed class Fax
// {
//     public Fax(TestManaeger tm)
//     {
//         tm.Message += FaxMsg;
//     }
//     private void FaxMsg(object? sender, TestEventArgs e)
//     {
//         System.Console.WriteLine($"Fax message {e.One} {e.Two}");
//     }
//     public void Unregistered(TestManaeger tm)
//     {
//         tm.Message -= FaxMsg;
//     }
// }

// public sealed class OperationTimer : IDisposable
// {
//     private readonly string _text;
//     private readonly int _collectionCount;
//     private readonly Stopwatch _stopwatch;
//     public OperationTimer(String text)
//     {
//         PrepareForOperation();
//         _text = text;
//         _collectionCount = GC.CollectionCount(0);

//         _stopwatch = Stopwatch.StartNew();
//     }

//     public void Dispose()
//     {
//         System.Console.WriteLine("{0} (GCs={1,3}) {2}", _stopwatch.Elapsed, GC.CollectionCount(0) - _collectionCount, _text);
//     }
//     private static void PrepareForOperation()
//     {
//         GC.Collect();
//         GC.WaitForPendingFinalizers();
//         GC.Collect();
//     }
// }