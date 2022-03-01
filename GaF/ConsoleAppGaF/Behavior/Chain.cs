namespace ConsoleAppGaF.Behavior;

interface IHandler
{
    IHandler SetNext(IHandler handler);
    object Handle(object request);
}
abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;
    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }
    public virtual object Handle(object request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        else
        {
            return null;
        }
    }
}
class MonkeyHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string) == "Banana")
        {
            return $"Monkey: eat the {request}";
        }
        else
        {
            return base.Handle(request);
        }
    }
}
class DogHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string) == "Meat")
        {
            return $"Dog: eat the {request}";
        }
        else
        {
            return base.Handle(request);
        }
    }
}
