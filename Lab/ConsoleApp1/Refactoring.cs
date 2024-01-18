namespace ConsoleApp1;

public class Refactoring
{
}

public class Employee
{
    public const int ENGINEER = 1;
    public const int MANAGER = 2;

    private readonly int _type;

    protected Employee(int type)
    {
        _type = type;
    }

    public static Employee CreateWith(string name)
    {
        try
        {
            return (Employee)Activator.CreateInstance(Type.GetType(name));
        }
        catch (Exception e)
        {
            throw new IndexOutOfRangeException();
        }
    }
}

public class Engineer : Employee
{
    public Engineer() : base(ENGINEER)
    {
    }
}

public class Manager : Employee
{
    public Manager() : base(MANAGER)
    {
    }
}