namespace ConsoleAppGaF.Struct;

public interface ISubject
{
    void Request();
}
class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request");
    }
}
class Proxy : ISubject
{
    private ISubject _subject;
    public Proxy(RealSubject realSubject)
    {
        _subject = realSubject;
    }
    public void Request()
    {
        _subject.Request();
    }
}

