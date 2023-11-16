using Microsoft.Extensions.Configuration;

namespace ConsoleApp1;

static class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Опытное приложение работы с базой данных");
        var connectionString = getProviderFromConfiguration();

        var repo = new WorkerRepo(connectionString);
        Console.WriteLine("Первоначально:");
        foreach (var w in await repo.GetAll())
        {
            Console.WriteLine($"{w.Id} {w.Name} {w.Birthday}");
        }
        var newWorker = new Worker
        {
            Id = -1,
            Name = "Новое имя",
            Birthday = new DateTime(1988, 1, 1),
        };
        var newId = await repo.Add(newWorker);
        var updated = await repo.Get(newId);
        updated.Name = "Новое имя";
        await repo.Update(updated);
        Console.WriteLine("После добавления и редактирования:");
        foreach (var w in await repo.GetAll())
        {
            Console.WriteLine($"{w.Id} {w.Name} {w.Birthday}");
        }
        await repo.Delete(newId);
        Console.WriteLine("После удаления:");
        foreach (var w in await repo.GetAll())
        {
            Console.WriteLine($"{w.Id} {w.Name} {w.Birthday}");
        }

        //var fabric = new ExecutorFabric<Worker>(connectionString);

        //await using (var executor = fabric.CreateReturn())
        //{
        //    executor.AddCommand("SELECT count(*) FROM workers;");
        //    var count = await executor.ExecuteReturn<long>();
        //    Console.WriteLine($"Count: {count}");
        //}

        //await using (var executor = fabric.CreateEnumerableRead())
        //{
        //    executor.AddCommand("SELECT id,name,birthday FROM workers;");
        //    var all = await executor.EnumerableRead(executor.AutoMap<Worker>);
        //    foreach (var w in all)
        //    {
        //        Console.WriteLine($"{w.Id} {w.Name} {w.Birthday}");
        //    }
        //}

        //await using (var executor = new ReadExecutor<Worker>(connectionString))
        //{
        //    executor.AddCommand("SELECT id,name,birthday FROM workers WHERE id=@id;", 
        //        new DalParameter("@id", 1));
        //    var item = await executor.Read(executor.AutoMap<Worker>);
        //    Console.WriteLine($"found: {item.Id} {item.Name} {item.Birthday}");
        //}

        //await using (var executor = new VoidExecutor<Worker>(connectionString))
        //{
        //    var newWorker = new Worker(0, "Новый", DateTime.Now);
        //    executor.AddCommand("INSERT INTO workers (name,birthday) VALUES (@name,@birthday);", newWorker);
        //    var count = await executor.Execute();
        //    Console.WriteLine($"Added, count: " + count);
        //}

        //var lastId = default(int);
        //await using (var executor = new ReturnExecutor<Worker>(connectionString))
        //{
        //    executor.AddCommand("SELECT id FROM workers ORDER BY id desc LIMIT 1");
        //    lastId = await executor.ExecuteReturn<int>();
        //}

        //var itemUpdating = default(Worker);
        //await using (var executor = new ReadExecutor<Worker>(connectionString))
        //{
        //    executor.AddCommand("SELECT id,name,birthday FROM workers WHERE id=@id;",
        //        new DalParameter("@id", lastId));
        //    itemUpdating = await executor.Read(executor.AutoMap<Worker>);
        //}
        //await using (var executor = new VoidExecutor<Worker>(connectionString))
        //{
        //    itemUpdating.Name = "Измененное имя";
        //    executor.AddCommand("UPDATE workers SET name=@name,birthday=@birthday WHERE id=@id;", itemUpdating);
        //    var count = await executor.Execute();
        //    Console.WriteLine($"Updated, count: " + count);
        //}

        //await using (var executor = new EnumerableReadExecutor<Worker>(connectionString))
        //{
        //    executor.AddCommand("SELECT id,name,birthday FROM workers;");
        //    var all = await executor.EnumerableRead(executor.AutoMap<Worker>);
        //    foreach (var w in all)
        //    {
        //        Console.WriteLine($"{w.Id} {w.Name} {w.Birthday}");
        //    }
        //}

        //await using (var executor = new VoidExecutor<Worker>(connectionString))
        //{
        //    executor.AddCommand("DELETE FROM workers WHERE id=@id;",
        //        new DalParameter("@id", lastId));
        //    var count = await executor.Execute();
        //    Console.WriteLine($"Deleted, count: " + count);
        //}





        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();

    }


    static string getProviderFromConfiguration()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var providerName = config["ProviderName"];
        return config[$"{providerName}:ConnectionString"];
    }
}



