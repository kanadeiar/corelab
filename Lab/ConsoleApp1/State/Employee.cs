namespace ConsoleApp1.State;

public abstract class Employee
{
    private EmployeeCode _type;

    public Employee(EmployeeType type)
    {
        Type = type;
    }

    public EmployeeType Type
    {
        get => _type.GetTypeCode();
        set => _type = EmployeeCode.CreateInstance(value);
    }

    public int PayAmount()
    {
        return _type.PayAmount(this);
    }
}