namespace SimpleConsole;

abstract class Abstract
{
    protected int Value { get; set; }
    public virtual string TestAbstract() => "Abstract";
    public abstract string Test();
}

internal class Sample : Abstract
{
    public override string Test() => "Base";
}

internal sealed class AdvSample : Sample
{
    public sealed override string Test()
    {
        return base.Test() + "Adv";
    }
}


internal struct SampleVal
{
    public SampleVal(out int val)
    {
        val = 10;
    }
}


record SampleRec(int Value, bool It);
record class SampleRecClass(int Value, bool It) : SampleRec(Value, It);
readonly record struct SampleRecStruct(int Value, bool It);


