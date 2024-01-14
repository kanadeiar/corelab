namespace ConsoleApp1.State;

public class Manager : EmployeeCode
{
    public override EmployeeType GetTypeCode()
    {
        return EmployeeType.Manager;
    }

    public override int PayAmount(Employee employee)
    {
        return 2;
    }
}