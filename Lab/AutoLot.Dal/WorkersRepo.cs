using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLot.Dal.Executor;

namespace AutoLot.Dal
{
    public class WorkersRepo
    {
        private readonly string _connectionString;

        public WorkersRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Worker> GetAll()
        {
            using var executor = new ReadExecutor<Worker>(_connectionString);
            executor.AddCommand("SELECT id, name FROM workers;");
            var workers = executor.Read(reader => new Worker
            {
                Id = (int)reader.GetValue(0),
                Name = (string)reader.GetValue(1),
            });
            return workers;
        }
    }
}
