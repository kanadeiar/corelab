namespace ConsoleAppGaF.Behavior;

public interface IComponent
{
    void Accept(IVisitor visitor);
}
public class ConcreteComponentA : IComponent
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteComponentA(this);
    }
    public string ExclusiveMethodOfConcreteComponentA()
    {
        return "A";
    }
}
public interface IVisitor
{
    void VisitConcreteComponentA(ConcreteComponentA element);
}
class ConcreteVisitor : IVisitor
{
    public void VisitConcreteComponentA(ConcreteComponentA element)
    {
        Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + Concrete Visitor 1");
    }
}
