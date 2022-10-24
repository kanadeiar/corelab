using System.Data;
using System.Runtime.InteropServices;
using Kanadeiar.Core.Async;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SimpleConsole;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        var strategy = context.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            using var trans = context.Database.BeginTransaction();
            context.Database.ExecuteSqlRaw($"ALTER TABLE dbo.Samples SET (SYSTEM_VERSIONING = OFF)");
            context.Database.ExecuteSqlRaw($"DELETE FROM audits.SamplesHistory");
            context.Database.ExecuteSqlRaw($"ALTER TABLE dbo.Samples SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE={historySchema}.{historyTable}))");
            trans.Commit();
        });


        using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
        {
            var samples = context.Samples
                .TemporalAll()
                .OrderBy(x => EF.Property<DateTime>(x, "ValidFrom"))
                .Select(x => new
                {
                    Sample = x,
                    ValidFrom = EF.Property<DateTime>(x, "ValidFrom"),
                    ValidTo = EF.Property<DateTime>(x, "ValidTo"),
                });
            foreach (var x in samples)
            {
                Console.WriteLine($"{x.Name} - {x.ValidFrom}, {x.ValidTo}");
            }


            var newSample = new Sample();
            context.Samples.Add(newSample);
            context.Entry(newSample).Property("IsDeleted").CurrentValue = true;
            var nonDeleteds = context.Samples.Where(c => !EF.Property<bool>(c, "IsDeleted")).ToList();
            foreach (var e in nonDeleteds)
            {
                Console.WriteLine($"{e.Name} Is deleted: {context.Entry(e).Property("IsDeleted").CurrentValue}");
            }
        }
        Console.WriteLine("Начало программы");
        var one = "ddd"u8;

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











