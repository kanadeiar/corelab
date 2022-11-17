using System.Diagnostics;

Console.WriteLine("Console application");

var res = Sample.Add(10, 3.3);
Console.WriteLine(res);
res = Sample.Sub(res, 5);
Console.WriteLine(res);



Console.WriteLine("Press any key to end...");
var _ = Console.ReadKey();


