namespace ConsoleApp1.Subclasses;

public abstract class Employee
{
    public static Employee CreateInstance(EmployeeType type)
    {
        switch (type)
        {
            case EmployeeType.Engineer:
                return new Engineer();
            case EmployeeType.Manager:
                return new Manager();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public abstract EmployeeType Type();
}