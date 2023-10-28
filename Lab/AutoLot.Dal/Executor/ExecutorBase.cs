using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AutoLot.Dal.Executor
{
    public abstract class ExecutorBase : IDisposable
    {
        private NpgsqlConnection _connection;
        protected IList<(string, NpgsqlParameter[])> configs = new List<(string, NpgsqlParameter[])>();

        public ExecutorBase(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }
        

        public void AddCommand(string sql, params NpgsqlParameter[] pars)
        {
            configs.Add((sql, pars));
        }

        public void Reset()
        {
            configs.Clear();
        }

        protected NpgsqlCommand initCommand((string, NpgsqlParameter[]) config)
        {
            var command = _connection.CreateCommand();
            command.CommandText = config.Item1;
            command.Parameters.AddRange(config.Item2);
            return command;
        }

        protected void openConnection()
        {
            _connection.Open();
            if (_connection.State != ConnectionState.Open)
            {
                throw new ApplicationException("Не удалось открыть соединение с БД");
            }
        }

        protected void closeConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
