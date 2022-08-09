

Action<int> action1;
Func<int, int> func1;

int? val = 5;
int val2 = val ?? 4;

int? nullablelnt = null;
nullablelnt ??= 12;
nullablelnt ??= 14;

(string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");

string[] strs = { "1", "2", "3", "4", "5" };
var elem = strs[^2];

// использование
SampleVal v1 = new();
var v2 = new SampleVal(10);

Console.WriteLine("Нажмите любую кнопку ...");
var v = Console.Read();

internal struct SampleVal
{
    public int value = 10;
    public int Val2 { get; set; }
    public SampleVal()
    {
        Val2 = 20;
    }
    public SampleVal(Int32 value)
    {
        this = new SampleVal();
        value = 10;
    }
}


