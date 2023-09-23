using System.Data;
using AutoLot.Dal.Models;
using Npgsql;

namespace AutoLot.Dal.DataOperations;

public class DalBase : IDisposable
{
    private readonly string _connectionString;
    private IDbConnection? _connection;
    private IDbCommand? _command;
    private bool _disposed = false;

    public DalBase(string connectionString)
    {
        _connectionString = connectionString;
        openConnection();
    }

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

    protected IEnumerable<CarView> executeEnumerableReader()
    {
        using var reader = _command.ExecuteReader();
        var id = reader.GetOrdinal("Id");
        var make = reader.GetOrdinal("Make");
        var name = reader.GetOrdinal("Name");
        var color = reader.GetOrdinal("Color");
        while (reader.Read())
        {
            yield return new CarView
            {
                Id = reader.GetInt32(id),
                Make = reader.GetString(make),
                Name = reader.GetString(name),
                Color = reader.GetString(color),
            };
        }
    }

    protected Car? executeGetReader()
    {
        using var reader = _command.ExecuteReader();
        var id = reader.GetOrdinal("Id");
        var makeId = reader.GetOrdinal("MakeId");
        var name = reader.GetOrdinal("Name");
        var color = reader.GetOrdinal("Color");
        if (reader.Read())
        {
            return new Car
            {
                Id = reader.GetInt32(id),
                MakeId = reader.GetInt32(makeId),
                Name = reader.GetString(name),
                Color = reader.GetString(color),
            };
        }

        return null;
    }

    protected CarView? executeGetViewReader()
    {
        using var reader = _command.ExecuteReader();
        var id = reader.GetOrdinal("Id");
        var make = reader.GetOrdinal("Make");
        var name = reader.GetOrdinal("Name");
        var color = reader.GetOrdinal("Color");
        if (reader.Read())
        {
            return new CarView
            {
                Id = reader.GetInt32(id),
                Make = reader.GetString(make),
                Name = reader.GetString(name),
                Color = reader.GetString(color),
            };
        }

        return null;
    }

    protected void executeNonQuery()
    {
        _command.ExecuteNonQuery();
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