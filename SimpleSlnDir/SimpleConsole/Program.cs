using Kanadeiar.Core.Async;
using Microsoft.EntityFrameworkCore;

namespace SimpleConsole;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
        {
            var entities = new[]
            {
                typeof(Driver).FullName,
                typeof(Sample).FullName,
                typeof(Make).FullName,
            };
            foreach (var entityName in entities)
            {
                var entity = context.Model.FindEntityType(entityName);
                var tableName = entity.GetTableName;
                var schemaName = entity.GetSchema;
                context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
                context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 0)");
            }

            // List<Make> makes = new()
            // {
            //     new() { Name = "Test" },
            //     new() { Name = "Dott" },
            // };
            // context.Makes.AddRange(makes);
            // context.SaveChanges();
            // List<Sample> samples = new()
            // {
            //     new() { MakeId = 1, Name = "Vova" },
            //     new() { MakeId = 2, Name = "Maka" },
            // };
            // context.Samples.AddRange(samples);
            // context.SaveChanges();
            // var list = new List<Sample>{
            //     new Sample(),
            //     new Sample(),
            //     new Sample(),
            // };
            // context.Samples.AddRange(list);
            // var make = new Make { Name = "Make" };
            // var sample = new Sample { Name = "One" };
            // ((List<Sample>)make.Samples).Add(sample);
            // context.Makes.Add(make);
            // context.SaveChanges();
            // var samples = context.Samples.Where(x => x.Name == "Test"); // оценка
            // var result = samples.ToList(); // выполнение
            // result = context.Samples.Where(x => x.Name == "Sim").ToList(); // немедленное выполнение
            // var query = context.Samples.AsQueryable(); // запрос
            // query = query.Where(x => x.Name == "Two");
            // result = query.ToList(); // получение
            // var one = context.Samples.AsNoTrackingWithIdentityResolution().FirstOrDefault(x => x.Id == 1);
        }

        Console.WriteLine("Начало программы");

        var f = new FileInfo("test.dat");
        using (var bw = new BinaryWriter(f.OpenWrite()))
        {
            System.Console.WriteLine(bw.BaseStream);
            var a = 1234.5;
            var i = 12345;
            var s = "1,2,3";
            bw.Write(a);
            bw.Write(i);
            bw.Write(s);
        }
        using (var br = new BinaryReader(f.OpenRead()))
        {
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
        }

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











