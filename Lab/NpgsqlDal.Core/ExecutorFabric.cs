using NpgsqlDal.Core.Executor;

namespace NpgsqlDal.Core;

public class ExecutorFabric<T>
    where T : class
{
    private readonly string _connectionString;

    public ExecutorFabric(string connectionString)
    {
        _connectionString = connectionString;
    }

    public EnumerableReadExecutor<T> CreateEnumerableRead()
    {
        var executor = new EnumerableReadExecutor<T>(_connectionString);
        return executor;
    }

    public ReadExecutor<T> CreateRead()
    {
        var executor = new ReadExecutor<T>(_connectionString);
        return executor;
    }

    public ReturnExecutor<T> CreateReturn()
    {
        var executor = new ReturnExecutor<T>(_connectionString);
        return executor;
    }

    public VoidExecutor<T> CreateVoid()
    {
        var executor = new VoidExecutor<T>(_connectionString);
        return executor;
    }
}