namespace ConsoleAppGaF.Behavior;

abstract class AbstractClass
{
    public void TemplateMethod()
    {
        BaseOperation();
        RequiredOperation();
        Hook();
        BaseOperation();
    }
    protected void BaseOperation()
    {
        Console.WriteLine("Base operation");
    }
    protected abstract void RequiredOperation();
    protected virtual void Hook() { }
}
class ConcreteClass1 : AbstractClass
{
    protected override void RequiredOperation()
    {
        Console.WriteLine("Concrete class 1 implement operation");
    }
}
class ConcreteClass2 : AbstractClass
{
    protected override void RequiredOperation()
    {
        Console.WriteLine("Concrete class 2 implement operation");
    }
    protected override void Hook()
    {
        Console.WriteLine("Override hook");
    }
}

