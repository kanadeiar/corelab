namespace ConsoleAppGaF.Creational;
/// <summary> Абстрактный создатель </summary>
interface ICreator
{
    public IProduct FactoryMethod();
    public string SomeOperation()
    {
        var product = FactoryMethod();
        var result = $"Creator: {product.Operation()}";
        return result;
    }
}
class ConcreteCreator1 : ICreator
{
    public IProduct FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}
/// <summary> Продукт </summary>
public interface IProduct
{
    string Operation();
}
class ConcreteProduct1 : IProduct
{
    public string Operation()
    {
        return "[Result of ConcreteProduct1]";
    }
}
