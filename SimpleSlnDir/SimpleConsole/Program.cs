

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
var v2 = new SampleVal() with { Val2 = 20 };
System.Console.WriteLine($"{v2.value} {v2.Val2}");

var p1 = new Point { X = 1, Y = 2 };
// var values = p1.Deconstruct();
// Console.WriteLine($"X is: {values.XPos}");
// Console.WriteLine($"Y is: {values.YPos}");


var rez = p1 switch
{
    (0, 0) => "начало",
    var (х, у) when х > 0 && у > 0 => "один",
    var (х, у) when х < 0 && у > 0 => "два",
    (_, _) => "отсутствие",
};

Console.WriteLine("Нажмите любую кнопку ...");
var v = Console.Read();

static string GetVal((string one, string two) value)
{
    return value switch
    {
        ("one", "two") => "OneTwo",
        (_) => "Default",
    };
}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public void Deconstruct(out int XPos, out int YPos) => (XPos, YPos) = (X, Y);
}

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


