using System.Data;
using Npgsql;
using NpgsqlDal.Core.Common;
using NpgsqlDal.Core.Exception;

namespace NpgsqlDal.Core.Executor
{
    public abstract class ExecutorBase<T> : IDisposable, IAsyncDisposable
        where T : class
    {
        private static ExecutorReflection<T> __reflection;
        private const int ThreadsCount = 8;
        protected static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(ThreadsCount, ThreadsCount);
        
        private NpgsqlConnection _connection;
        private List<DalCommand> _commands = new ();

        static ExecutorBase()
        {
            __reflection = new ExecutorReflection<T>();
        }

        protected ExecutorBase(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public void AddCommand(string sql, T item)
        {
            AddCommand(sql, __reflection.GetParameters(item));
        }

        public void AddCommand(string sql, params DalParameter[] pars)
        {
            _commands.Add(new DalCommand(sql, pars));
        }
        
        public void Reset()
        {
            _commands.Clear();
        }

        public TNew AutoMap<TNew>(NpgsqlDataReader dataReader)
            where TNew : new()
        {
            return __reflection.AutoMap<TNew>(dataReader);
        }

        protected async Task openConnection(CancellationToken token = default)
        {
            if (_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync(token);
            }
            if (_connection.State != ConnectionState.Open)
                throw new DalException("Не удалось открыть соединение с базой данных");
        }

        protected IEnumerable<NpgsqlCommand> initAllCommands()
        {
            foreach (var com in _commands)
            {
                var command = createCommand(com);
                yield return command;
            }
        }

        protected NpgsqlCommand initLastCommand()
        {
            if (_commands.LastOrDefault() is var com)
            {
                var command = createCommand(com);
                return command;
            }
            throw new DalException("Не настроен исполнитель команд");
        }

        private NpgsqlCommand createCommand(DalCommand com)
        {
            var command = _connection.CreateCommand();
            command.CommandText = com.Sql;
            foreach (var par in com.Parameters)
            {
                command.Parameters.AddWithValue(par.Name, par.Value);
            }

            return command;
        }

        protected async Task closeConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                await _connection.CloseAsync();
            }
        }
        
        #region Dispose

        void IDisposable.Dispose()
        {
            _connection.Dispose();
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            await _connection.DisposeAsync();
        }

        #endregion
    }
}
