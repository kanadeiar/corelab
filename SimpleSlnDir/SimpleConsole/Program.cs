using System.Data;

namespace SimpleConsole;

record class Info(string Name, int Number, int Desc);

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Начало программы");


        var infos = Enumerable.Range(1, 10)
            .Select(x => new { Name = $"Имя{x}", Infos = new List<Info> { new Info($"N{x}", x, x) } });
        var converted = infos.SelectMany(x => x.Infos, (x, y) => new { Name = x.Name, InfoName = y.Name });
        foreach (var el in converted)
        {
            Console.Write($"{el.Name} {el.InfoName} ");
        }



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











