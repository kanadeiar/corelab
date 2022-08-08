

int? val = 5;
int val2 = val ?? 4;

int? nullablelnt = null;
nullablelnt ??= 12;
nullablelnt ??= 14;

(string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");

string[] strs = { "1", "2", "3", "4", "5" };
var elem = strs[^2];


Console.WriteLine("Нажмите любую кнопку ...");
var v = Console.Read();



