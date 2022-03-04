namespace ConsoleAppGaF.Behavior.Strategy;

class Context
{
    private IStrategy _strategy;
    public Context()
    { }
    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }
    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }
    public void DoSomeBusinessLogic()
    {
        Console.WriteLine("Context: Sorting data using the strategy");
        var results = _strategy.DoIt(new List<int> { 1, 2, 3 });
        var strs = string.Join(", ", results as List<int>);
        Console.WriteLine(strs);
    }
}
interface IStrategy
{
    object DoIt(object data);
}
class ConcreteStrategyA : IStrategy
{
    public object DoIt(object data)
    {
        var list = data as List<int>;
        list.Sort();
        return list;
    }
}
class ConcreteStrategyB : IStrategy
{
    public object DoIt(object data)
    {
        var list = data as List<int>;
        list.Sort();
        list.Reverse();
        return list;
    }
}
