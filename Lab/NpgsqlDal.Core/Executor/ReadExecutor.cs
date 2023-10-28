using Npgsql;

namespace NpgsqlDal.Core.Executor;

public class ReadExecutor<T> : ExecutorBase<T>
    where T : class
{
    public ReadExecutor(string connectionString) : base(connectionString)
    {
    }

    public async Task<T?> Read(Func<NpgsqlDataReader, T> reader, CancellationToken token = default)
    {
        await Semaphore.WaitAsync(token);
        try
        {
            await openConnection(token);
            var item = await getItemFromDatabase(reader, token);
            return item;
        }
        finally
        {
            await closeConnection();
            Semaphore.Release();
        }
    }

    private async Task<T?> getItemFromDatabase(Func<NpgsqlDataReader, T> reader, CancellationToken token = default)
    {
        var item = default(T);
        await using var command = initLastCommand();
        var localReader = await command.ExecuteReaderAsync(token);
        if (await localReader.ReadAsync(token))
        {
            item = reader.Invoke(localReader);
        }
        return item;
    }
}