namespace NpgsqlDal.Core;

public abstract class RepositoryBase<T>
    where T : class
{
    private readonly string _connectionString;

    protected ExecutorFabric<T> Fabric;

    protected RepositoryBase(string connectionString)
    {
        _connectionString = connectionString;
        Fabric = new ExecutorFabric<T>(_connectionString);
    }
}