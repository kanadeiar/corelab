using SimpleConsole;

var rec = new SampleRec(10, true);
var same = rec;
var copy = rec with { };
var two = rec with { Value = 10 };



var resources = new Resources();

var ints = resources.Set<int>();
ints.Add("1", new Resource<int> { MyValue = 1 });
ints.Add("2", new Resource<int> { MyValue = 2 });
ints.Add("3", new IntResource { MyValue = 4 });
foreach (var e in ints)
{
    Console.WriteLine($"{e.Key} {e.Value.MyValue}");
}
resources.Set<double>().Add("1", new Resource<double>());
resources.Set<string>().Add("1", new Resource<string>());



Console.WriteLine("Нажмите любую кнопку ...");
var v = Console.Read();


public interface IResource<T>
{
    public string Uri { get; set; }
    public T MyValue { get; set; }
}
public class Resource<T> : IResource<T>
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