using System.Data;
using AutoLot.Dal.Models;
using Npgsql;

namespace AutoLot.Dal.DataOperations;

public abstract class DalBase : IDisposable
{
    protected readonly string _connectionString;
    private IDbConnection? _connection;
    private IDbCommand? _command;
    private bool _disposed = false;

    protected DalBase(string connectionString)
    {
        _connectionString = connectionString;
        openConnection();
    }

    private string[] _columnNames;
    private IDictionary<string, int> _ordinals;

    protected void setColumnNames(params string[] names)
    {
        _columnNames = names;
    }

    protected void initPositions(IDataReader reader)
    {
        var ordinals = new Dictionary<string, int>();
        foreach (var name in _columnNames)
        {
            var ord = reader.GetOrdinal(name);
            ordinals[name] = ord;
        }
        _ordinals = ordinals;
    }

    private int posInOrdinals = default;
    protected int first => _ordinals[_columnNames[posInOrdinals = 0]];
    protected int next => _ordinals[_columnNames[++posInOrdinals]];

    protected void openConnection()
    {
        if (_connection is null)
        {
            _connection = new NpgsqlConnection()
            {
                ConnectionString = _connectionString
            };
        }
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
    }

    protected void closeConnection()
    {
        if (_connection?.State != ConnectionState.Closed)
        {
            _connection?.Close();
        }
    }

    protected void createSqlCommand(string sql)
    {
        _command = _connection.CreateCommand();
        _command.CommandText = sql;
    }

    protected void addParameter(string name, DbType type, object value, ParameterDirection direction)
    {
        var param = _command.CreateParameter();
        param.ParameterName = name;
        param.DbType = type;
        param.Value = value;
        param.Direction = direction;
        _command.Parameters.Add(param);
    }

    protected IDataReader executeReader()
    {
        var reader = _command.ExecuteReader();
        return reader;
    }

    protected void executeNonQuery()
    {
        _command.ExecuteNonQuery();
    }

    protected object executeScalar()
    {
        var result = _command.ExecuteScalar();
        return result;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            closeConnection();
            _connection.Dispose();
            _command.Dispose();
        }
        _disposed = true;
    }

    void IDisposable.Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}