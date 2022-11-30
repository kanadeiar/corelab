
var baseVal = default(int);
do
{
    Console.WriteLine("Input base:> ");
} while (!int.TryParse(Console.ReadLine(), out baseVal));
var heightVal = default(int);
do
{
    Console.WriteLine("Input height:> ");
} while (!int.TryParse(Console.ReadLine(), out heightVal));

var areaVal = baseVal * heightVal / 2;
Console.WriteLine($"area: {areaVal}");

var _ = Console.ReadKey();
