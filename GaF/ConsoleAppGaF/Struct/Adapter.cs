namespace ConsoleAppGaF.Struct;

/// <summary> Целевой исходный класс </summary>
public sealed class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request.";
    }
}
public interface ITarget
{
    string GetMyRequest();
}
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;
    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }
    public string GetMyRequest()
    {
        return $"This is adapter: {_adaptee.GetSpecificRequest()}";
    }
}
