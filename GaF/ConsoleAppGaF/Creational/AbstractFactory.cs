namespace ConsoleAppGaF.Creational;

public interface IAbstractFactory
{
    IAbstractProductA CreateProductA();
}
class ConcreteFactory1 : IAbstractFactory
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }
}
public interface IAbstractProductA
{
    string UsefulFunctionA();
}
class ConcreteProductA1 : IAbstractProductA
{
    public string UsefulFunctionA()
    {
        return "The result of the product A1.";
    }
}
