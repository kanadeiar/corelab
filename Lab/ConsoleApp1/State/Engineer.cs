namespace ConsoleApp1.State;

public class Engineer : EmployeeCode
{
    public override EmployeeType GetTypeCode()
    {
        return EmployeeType.Engineer;
    }

    public override int PayAmount(Employee employee)
    {
        return 1;
    }
}