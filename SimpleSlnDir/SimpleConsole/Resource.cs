namespace SimpleConsole;

public class Resource<T> : IResource<T>
{
    public string Uri { get; set; }
    public T MyValue { get; set; }
}
public interface IResource<T>
{
    public string Uri { get; set; }
    public T MyValue { get; set; }
}
public class IntResource : Resource<int>, IResource<int>
{
    public string Uri { get; set; }
    public int MyValue { get; set; }
}

public class Resources
{
    public IDictionary<string, IResource<int>> Dict { get; } = new Dictionary<string, IResource<int>>();
    public IDictionary<string, IResource<double>> Dict2 { get; } = new Dictionary<string, IResource<double>>();
    public IDictionary<string, IResource<string>> Dict3 { get; } = new Dictionary<string, IResource<string>>();

    public IDictionary<string, IResource<T>> Set<T>()
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Int32:
                return (IDictionary<string, IResource<T>>)Dict;
            case TypeCode.Double:
                return (IDictionary<string, IResource<T>>)Dict2;
            case TypeCode.String:
                return (IDictionary<string, IResource<T>>)Dict3;
            default:
                return null;
        }
    }
}
