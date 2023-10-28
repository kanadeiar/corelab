using System.Runtime.CompilerServices;
using Npgsql;

namespace NpgsqlDal.Core.Executor;

public class EnumerableReadExecutor<T> : ExecutorBase<T>
    where T : class
{
    public EnumerableReadExecutor(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<T>> EnumerableRead(Func<NpgsqlDataReader, T> reader, [EnumeratorCancellation]CancellationToken token = default)
    {
        await Semaphore.WaitAsync(token);
        try
        {
            await openConnection(token);
            var items = await getItemsFromDatabase(reader, token);
            return items;
        }
        finally
        {
            await closeConnection();
            Semaphore.Release();
        }
    }

    private async Task<IEnumerable<T>> getItemsFromDatabase(Func<NpgsqlDataReader, T> reader, CancellationToken token = default)
    {
        var items = new List<T>();
        await using var command = initLastCommand();
        var localReader = await command.ExecuteReaderAsync(token);
        while (await localReader.ReadAsync(token))
        {
            items.Add(reader.Invoke(localReader));
        }
        return items;
    }
}