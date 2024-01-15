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
    private EmployeeCode _code;

    public EmployeeCode Code
    {
        get => _code;
        set => _code = value;
    }

    public Employee(EmpType code)
    {
        Code = EmployeeCode.NewCode(code);
    }

    public int PayAmount()
    {
        switch (_code)
        {
            case Engineer:
                return 10;
            case Manager: 
                return 20;
            default:
                throw new IndexOutOfRangeException();
        }
    }
}

public abstract class EmployeeCode
{
    public abstract EmpType GetCode();

    public static EmployeeCode NewCode(EmpType value)
    {
        switch (value)
        {
            case EmpType.Engineer:
                return new Engineer();
            case EmpType.Manager:
                return new Manager();
            default:
                throw new IndexOutOfRangeException();
        }
    }
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

