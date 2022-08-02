using System;

namespace CalculatorExamples;

// internal class ValueEventArgs : EventArgs
// {
//     private readonly int _value;
//     public ValueEventArgs(int value)
//     {
//         _value = value;
//     }
//     public int Value => _value;
// }

// internal class MySender
// {
//     public event EventHandler<ValueEventArgs>? NewValue;
//     protected virtual void OnNewValue(ValueEventArgs e)
//     {
//         if (Volatile.Read(ref NewValue) is { } temp)
//         {
//             temp(this, e);
//         }
//     }
//     public void Simulate(int value)
//     {
//         var e = new ValueEventArgs(value);
//         OnNewValue(e);
//     }
// }

public sealed class EventKey : Object { }

public sealed class EventSet
{
    private readonly Dictionary<EventKey, Delegate> _events = new Dictionary<EventKey, Delegate>();
    public void Add(EventKey key, Delegate handler)
    {
        Monitor.Enter(_events);
        _events.TryGetValue(key, out var d);
        _events[key] = Delegate.Combine(d, handler);
        Monitor.Exit(_events);
    }
    public void Remove(EventKey key, Delegate handler)
    {
        Monitor.Enter(_events);
        if (_events.TryGetValue(key, out var d))
        {
            d = Delegate.Remove(d, handler);
            if (d != null)
            {
                _events[key] = d;
            }
            else
            {
                _events.Remove(key);
            }
        }
        Monitor.Exit(_events);
    }
    public void Raise(EventKey key, Object sender, EventArgs e)
    {
        Monitor.Enter(_events);
        _events.TryGetValue(key, out var d);
        Monitor.Exit(_events);
        if (d != null)
        {
            d.DynamicInvoke(new Object[] { sender, e });
        }
    }
}

public class InvokeEventArgs : EventArgs { }

public class InvokeEvents
{
    private readonly EventSet _eventSet = new EventSet();
    protected EventSet EventSet { get => _eventSet; }
    // Идентификатор события
    protected static readonly EventKey _testEventKey = new EventKey();
    // Событие
    public event EventHandler<InvokeEventArgs> Test
    {
        add => _eventSet.Add(_testEventKey, value);
        remove => _eventSet.Remove(_testEventKey, value);
    }
    protected virtual void OnTest(InvokeEventArgs e)
    {
        _eventSet.Raise(_testEventKey, this, e);
    }
    public void Simulate()
    {
        OnTest(new InvokeEventArgs());
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var test = new InvokeEvents();
        test.Test += Method;
        test.Simulate();

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }
    private static void Method(Object? s, InvokeEventArgs e)
    {
        System.Console.WriteLine($"Test done");
    }
}

