

var dict = new Resources<int>();
dict.Dict.Add("1", new Resource<int>());







Console.WriteLine("Нажмите любую кнопку ...");
var v = Console.Read();


public interface IResource<T>
{
    public T MyValue { get; set; }
}
public class Resource<T> : IResource<T>
{
    public T MyValue { get; set; }
}

public class Resources<T>
{
    public IDictionary<string, IResource<T>> Dict { get; } = new Dictionary<string, IResource<T>>();
}