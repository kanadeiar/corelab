namespace SimpleConsole;

// public class Sample
// {
//     public string Name { get; set; } = default!;
//     public void Test(string name)
//     {
//         ArgumentNullException.ThrowIfNull(name);
//         // код
//     }
// }

internal sealed class Sample
{
    public int Value { get; init; }
    public Sample(int val)
    {
        Value = val;
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


