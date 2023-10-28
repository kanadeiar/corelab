using Npgsql;
using System.Reflection;

namespace NpgsqlDal.Core.Common;

public static class DalExtensions
{
    public static void MapDataFromReader<T>(this NpgsqlDataReader dataReader, T newObject)
    {
        if (newObject == null) throw new ArgumentNullException(nameof(newObject));

        var propertiesHashSet = newObject.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(x => x.Name, y => y);
        for (int i = 0; i < dataReader.FieldCount; i++)
        {
            if (propertiesHashSet.FirstOrDefault(x => string.Equals(x.Key, dataReader.GetName(i), StringComparison.InvariantCultureIgnoreCase)) is { } pair)
            {
                pair.Value.SetValue(newObject, dataReader.IsDBNull(i) ? null : dataReader.GetValue(i));
            }
        }
    }

    public static T GetFromReader<T>(this NpgsqlDataReader dataReader)
        where T : new()
    {
        var result = new T();
        dataReader.MapDataFromReader(result);
        return result;
    }

    //public static DalParameter[] GetDalParameters<T>(this T oldObject)
    //    where T : class
    //{
    //    var propertiesHashSet = oldObject.GetType()
    //        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
    //        .ToDictionary(x => x.Name, y => y);

    //    var results = new List<DalParameter>();
    //    foreach (var key in propertiesHashSet.Keys)
    //    {
    //        var value = propertiesHashSet[key].GetValue(oldObject);
    //        results.Add(new DalParameter($"@{key.ToLowerInvariant()}", value));
    //    }
    //    return results.ToArray();
    //}
}