using System.Data;

namespace SimpleConsole;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Начало программы");

        var arrInts = new[] { 2, -3, 4, 9, 0, 10 };
        Console.WriteLine($"Max = {(from i in arrInts select i).Max()}");
        Console.WriteLine($"Min = {arrInts.Min()}");
        Console.WriteLine($"Average = {(from i in arrInts select i).Average()}");
        Console.WriteLine($"Sum = {arrInts.Select(x => x).Sum()}");
        var arr1 = (from i in arrInts select i).Take(2);
        foreach (var el in arr1)
            Console.Write($"{el} ");
        Console.WriteLine();
        var arr2 = arrInts.Skip(2);
        foreach (var el in arr2)
            Console.Write($"{el} ");

        // var f = new FileInfo("test.dat");
        // using (var bw = new BinaryWriter(f.OpenWrite()))
        // {
        //     System.Console.WriteLine(bw.BaseStream);
        //     var a = 1234.5;
        //     var i = 12345;
        //     var s = "1,2,3";
        //     bw.Write(a);
        //     bw.Write(i);
        //     bw.Write(s);
        // }
        // using (var br = new BinaryReader(f.OpenRead()))
        // {
        //     Console.WriteLine(br.ReadDouble());
        //     Console.WriteLine(br.ReadInt32());
        //     Console.WriteLine(br.ReadString());
        // }
        // using (var swriter = new StringWriter())
        // {
        //     swriter.WriteLine("Test");
        //     var sb = swriter.GetStringBuilder();
        //     sb.Insert(0, "Hey!!! ");
        //     Console.WriteLine("Copy: {0}", swriter);
        //     using (var sreader = new StringReader(swriter.ToString()))
        //     {
        //         var input = default(string);
        //         while ((input = sreader.ReadLine()) != null)
        //         {
        //             Console.WriteLine(input);
        //         }
        //     }
        // }

        Console.WriteLine(Environment.NewLine + "Нажмите любую кнопку ...");
        var _ = Console.Read();
    }
}











