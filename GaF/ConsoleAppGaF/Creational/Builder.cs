namespace ConsoleAppGaF.Creational;
//абстрактный строитель
public interface IBuilder
{
    IBuilder BuildPartA();
    IBuilder BuildPartB();
}
public class ConcreteBuilder : IBuilder
{
    private Product _product = new Product();
    public void Reset()
    {
        _product = new Product();
    }
    public IBuilder BuildPartA()
    {
        _product.Add("PartA");
        return this;
    }
    public IBuilder BuildPartB()
    {
        _product.Add("PartB");
        return this;
    }
    public Product Get()
    {
        var result = _product;
        Reset();
        return result;
    }
}
public class Product
{
    public List<object> Parts = new List<object>();
    public void Add(string p) => Parts.Add(p);
}
//директор - выполнение по шагам
public class Direcrtor
{
    private IBuilder _builder;
    public IBuilder Builder
    {
        set => _builder = value;
    }
    public void BuildMinimal() => _builder.BuildPartA();
    public void BuildMaximum()
    {
        _builder.BuildPartA().BuildPartB();
    }
}
