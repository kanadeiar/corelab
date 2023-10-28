using Npgsql;

namespace NpgsqlDal.Core.Common;

internal record struct DalCommand(string Sql, params DalParameter[] Parameters);
