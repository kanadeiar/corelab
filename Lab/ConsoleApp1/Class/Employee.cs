namespace ConsoleApp1.Class;

public class Employee
{
    private EmployeeCode _code;

    public Employee(EmployeeType type)
    {
        _code = EmployeeCode.CreateCode(type);
    }
}