using System;

namespace CalculatorExamples;

internal class ValueEventArgs : EventArgs
{
    private readonly int _value;
    public ValueEventArgs(int value)
    {
        _value = value;
    }
    public int Value => _value;
}

internal class MySender
{
    public event EventHandler<ValueEventArgs>? NewValue;
    protected virtual void OnNewValue(ValueEventArgs e)
    {
        if (Volatile.Read(ref NewValue) is { } temp)
        {
            temp(this, e);
        }
    }
    public void Simulate(int value)
    {
        var e = new ValueEventArgs(value);
        OnNewValue(e);
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var sender = new MySender();
        sender.NewValue += Method;
        sender.Simulate(1);

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }
    private static void Method(Object? s, ValueEventArgs e)
    {
        System.Console.WriteLine($"Value = {e.Value}");
    }
}

