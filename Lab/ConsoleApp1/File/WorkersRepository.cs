namespace ConsoleApp1.File;

public class WorkersRepository : FileRepositoryBase<Worker>
{
    public WorkersRepository() : base(new FileData<Worker>("workers.json", "Workers"))
    {
        Init();
    }

    public override IEnumerable<Worker> Create()
    {
        var items = Enumerable.Range(1, 3).Select(x => new Worker
        {
            Id = x,
            Name = "Имя" + x,
            Birthday = DateTime.Now,
        });
        return items;
    }
}