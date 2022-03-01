namespace ConsoleAppGaF.Struct;

abstract class Component
{
    public abstract string Operation();
}
class ConcreteComponent : Component
{
    public override string Operation()
    {
        return "ConcreteComponent";
    }
}
class Decorator : Component
{
    protected Component _component;
    public Decorator(Component component)
    {
        _component = component;
    }
    public void SetComponent(Component component)
    {
        _component = component;
    }
    public override string Operation()
    {
        if (_component != null)
        {
            return _component.Operation();
        }
        else
        {
            return string.Empty;
        }
    }
}
class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(Component comp) : base(comp)
    {
    }
    public override string Operation()
    {
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}
