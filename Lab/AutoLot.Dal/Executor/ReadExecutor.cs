using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AutoLot.Dal.Executor
{
    public class ReadExecutor<T> : ExecutorBase
        where T : class
    {
        public ReadExecutor(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<T> Read(Func<NpgsqlDataReader, T> action)
        {
            openConnection();
            var items = ReadItemsFromDatabase(action);
            closeConnection();
            return items;
        }

        private List<T> ReadItemsFromDatabase(Func<NpgsqlDataReader, T> action)
        {
            using var command = initCommand(configs.Last());
            using var reader = command.ExecuteReader();
            var items = new List<T>();
            while (reader.Read())
            {
                items.Add(action.Invoke(reader));
            }
            return items;
        }
    }
}
