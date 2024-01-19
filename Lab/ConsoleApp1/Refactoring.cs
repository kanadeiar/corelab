namespace ConsoleApp1;

public class Refactoring
{
    public double Charge(IBillable emp, int days)
    {
        var bas = emp.GetRate() * days;
        if (emp.HasSpecialSkill())
        {
            return bas * 1.05;
        }

        return bas;
    }
}

public interface IBillable
{
    int GetRate();
    bool HasSpecialSkill();
}

public class Employee : IBillable
{
    public int GetRate()
    {
        return 10;
    }

    public bool HasSpecialSkill()
    {
        return true;
    }
}







