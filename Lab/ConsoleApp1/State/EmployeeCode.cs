namespace ConsoleApp1.State;

public abstract class EmployeeCode
{
    public abstract EmployeeType GetTypeCode();

    public static EmployeeCode CreateInstance(EmployeeType type)
    {
        switch (type)
        {
            case EmployeeType.Engineer:
                return new Engineer();
            case EmployeeType.Manager:
                return new Manager();
            default:
                throw new IndexOutOfRangeException();
        }
    }

    public abstract int PayAmount(Employee employee);
}