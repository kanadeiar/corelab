using NpgsqlDal.Core;
using NpgsqlDal.Core.Common;

namespace ConsoleApp1;

public class WorkerRepo : RepositoryBase<Worker>
{
    public WorkerRepo(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<Worker>> GetAll()
    {
        await using var executor = Fabric.CreateEnumerableRead();
        executor.AddCommand("SELECT id,name,birthday FROM workers;");
        var items = await executor.EnumerableRead(executor.AutoMap<Worker>);
        return items;
    }

    public async Task<Worker?> Get(int id)
    {
        await using var executor = Fabric.CreateRead();
        executor.AddCommand("SELECT id,name,birthday FROM workers WHERE id=@id;", 
            new DalParameter("@id", id));
        var item = await executor.Read(executor.AutoMap<Worker>);
        return item;
    }

    public async Task<int> Add(Worker worker)
    {
        await using var executor = Fabric.CreateReturn();
        executor.AddCommand("INSERT INTO workers (name,birthday) VALUES (@name,@birthday) RETURNING id;", worker);
        var id = await executor.ExecuteReturn<int>();
        return id;
    }

    public async Task<int> Update(Worker worker)
    {
        await using var executor = Fabric.CreateVoid();
        executor.AddCommand("UPDATE workers SET name=@name,birthday=@birthday WHERE id=@id;", worker);
        var count = await executor.Execute();
        return count;
    }

    public async Task<int> Delete(int id)
    {
        await using var executor = Fabric.CreateVoid();
        executor.AddCommand("DELETE FROM workers WHERE id=@id;",
            new DalParameter("@id", id));
        var count = await executor.Execute();
        return count;
    }
}