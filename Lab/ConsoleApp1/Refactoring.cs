using System.Diagnostics;

namespace ConsoleApp1;

public class Refactoring
{

}

public enum EmpType
{
    Engineer,
    Manager,
}

public class Employee
{
    private EmpType _code;

    public EmpType Code
    {
        get => _code;
        set => _code = value;
    }

    public Employee(EmpType code)
    {
        Code = code;
    }

    public int PayAmount()
    {
        switch (Code)
        {
            case EmpType.Engineer:
                return 10;
            case EmpType.Manager: 
                return 20;
            default:
                throw new IndexOutOfRangeException();
        }
    }
}

public abstract class EmployeeCode
{
    public abstract EmpType GetCode();
}

public class Engineer : EmployeeCode
{
    public override EmpType GetCode()
    {
        return EmpType.Engineer;
    }
}

public class Manager : EmployeeCode
{
    public override EmpType GetCode()
    {
        return EmpType.Manager;
    }
}

