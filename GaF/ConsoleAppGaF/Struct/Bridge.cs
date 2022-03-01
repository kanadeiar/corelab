namespace ConsoleAppGaF.Struct;
/// <summary> Абстракция </summary>
public class Abstraction
{
    private readonly IImplementation _implementation;
    public Abstraction(IImplementation implementation)
    {
        _implementation = implementation;
    }
    public virtual string Operation()
    {
        return $"Abstract: base with {_implementation.OperationImplementation()}";
    }
}
/// <summary> Дополнение </summary>
public class ExtendedAbstaction : Abstraction
{
    public ExtendedAbstaction(IImplementation implementation) : base(implementation)
    {
    }
    public override string Operation()
    {
        return $"Extended Abstraction: {base.Operation()}";
    }
}

public interface IImplementation
{
    string OperationImplementation();
}
public sealed class ConcreteImplementationA : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationA: The result in platform A.\n";
    }
}