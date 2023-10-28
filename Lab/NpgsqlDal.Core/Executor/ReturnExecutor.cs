namespace NpgsqlDal.Core.Executor;

public class ReturnExecutor<T> : ExecutorBase<T>
    where T : class
{
    public ReturnExecutor(string connectionString) : base(connectionString)
    {
    }

    public async Task<TResult> ExecuteReturn<TResult>(CancellationToken token = default)
    {
        await Semaphore.WaitAsync(token);
        try
        {
            await openConnection(token);
            var result = await getResultFromDatabase<TResult>(token);
            return result;
        }
        finally
        {
            await closeConnection();
            Semaphore.Release();
        }
    }

    private async Task<TResult> getResultFromDatabase<TResult>(CancellationToken token)
    {
        await using var command = initLastCommand();
        var obj = await command.ExecuteScalarAsync(token);
        var result = (TResult)obj!;
        return result;
    }
}