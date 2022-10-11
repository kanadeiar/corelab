using System.Data;
using Kanadeiar.Core.Async;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SimpleConsole;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
        {
            var filtereds = context.Ratios.ToArray(); // отфильтрованные сущности
            var alls = context.Samples.IgnoreQueryFilters().ToArray(); // игнор фильтра
            var make = context.Makes.First(x => x.Id == 1);
            context.Entry(make).Collection(x => x.Samples).Load(); // загрука сущностей отфильтрованных
            var samples = make.Samples.ToArray();
            context.Entry(make).Collection(x => x.Samples).Query().IgnoreQueryFilters().Load(); // игнор фильра
            var samples2 = make.Samples.ToArray();
        }
        Console.WriteLine("Начало программы");

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

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }
}











