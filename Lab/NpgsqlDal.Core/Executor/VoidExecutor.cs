namespace NpgsqlDal.Core.Executor;

public class VoidExecutor<T> : ExecutorBase<T>
    where T : class
{
    public VoidExecutor(string connectionString) : base(connectionString)
    {
    }

    public async Task<int> Execute(CancellationToken token = default)
    {
        await Semaphore.WaitAsync(token);
        try
        {
            await openConnection(token);
            var count = await executeAllToDatabase(token);
            return count;
        }
        finally
        {
            await closeConnection();
            Semaphore.Release();
        }
    }

    private async Task<int> executeAllToDatabase(CancellationToken token)
    {
        var count = default(int);
        var commands = initAllCommands().ToArray();
        foreach (var command in commands)
        {
            count += await command.ExecuteNonQueryAsync(token);
        }
        return count;
    }
}