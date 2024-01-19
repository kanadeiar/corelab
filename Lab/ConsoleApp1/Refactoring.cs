namespace ConsoleApp1;

public class Refactoring
{

}

public abstract class Employee
{
    public int GetSalary(int days)
    {
        var salary = Salary();
        var basic = salary * days;
        var prem = Prem(basic);
        return basic + prem;
    }

    protected abstract int Prem(int basic);
    protected abstract int Salary();
}

public class Engineer : Employee
{
    protected override int Prem(int basic)
    {
        return basic * 2;
    }

    protected override int Salary()
    {
        return 100;
    }
}

public class Managet : Employee
{
    protected override int Prem(int basic)
    {
        return basic * 3;
    }

    protected override int Salary()
    {
        return 200;
    }
}







