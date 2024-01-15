using System.Diagnostics;

namespace ConsoleApp1;

public class Refactoring
{

}


public enum EmpType
{
    None,
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
        return Code.PayAmount(this);
    }

    public int GetMonthlySalary()
    {
        return 10;
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
                return new engineer();
            case EmpType.Manager:
                return new manager();
            default:
                return nullCode.Instance();
        }
    }

    public abstract int PayAmount(Employee employee);
}

file class engineer : EmployeeCode
{
    public override EmpType GetCode()
    {
        return EmpType.Engineer;
    }

    public override int PayAmount(Employee employee)
    {
        return employee.GetMonthlySalary();
    }
}

file class manager : EmployeeCode
{
    public override EmpType GetCode()
    {
        return EmpType.Manager;
    }

    public override int PayAmount(Employee employee)
    {
        return employee.GetMonthlySalary() * 2;
    }
}

file class nullCode : EmployeeCode
{
    private static EmployeeCode? _instance;
    public static EmployeeCode Instance() => _instance ??= new nullCode();

    public override EmpType GetCode()
    {
        return EmpType.None;
    }

    public override int PayAmount(Employee employee)
    {
        return 0;
    }
}

