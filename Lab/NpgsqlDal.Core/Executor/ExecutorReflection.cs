using System.Collections.Frozen;
using System.Reflection;
using Npgsql;
using NpgsqlDal.Core.Common;

namespace NpgsqlDal.Core.Executor;

internal class ExecutorReflection<T>
    where T : class
{
    private static readonly IDictionary<string, PropertyInfo> __propertyInfos;

    static ExecutorReflection()
    {
        __propertyInfos = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToFrozenDictionary(x => x.Name, y => y);
    }

    public TNew AutoMap<TNew>(NpgsqlDataReader dataReader)
        where TNew : new()
    {
        var result = new TNew();
        for (int i = 0; i < dataReader.FieldCount; i++)
        {
            if (__propertyInfos.FirstOrDefault(x => string.Equals(x.Key, dataReader.GetName(i), StringComparison.InvariantCultureIgnoreCase)) is { } pair)
            {
                pair.Value.SetValue(result, dataReader.IsDBNull(i) ? null : dataReader.GetValue(i));
            }
        }
        return result;
    }

    public DalParameter[] GetParameters(T oldObject)
    {
        var results = new List<DalParameter>();
        foreach (var key in __propertyInfos.Keys)
        {
            var value = __propertyInfos[key].GetValue(oldObject);
            results.Add(new DalParameter($"@{key.ToLowerInvariant()}", value));
        }
        return results.ToArray();
    }
}
