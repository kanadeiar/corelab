namespace ConsoleApp1;

public class Person
{
    private Department _department;

    public Department Department => _department;

}

public class Department
{
    private readonly Person _manager;

    public Department(Person manager)
    {
        _manager = manager;
    }

    public Person GetManager()
    {
        return _manager;
    }

}


public class Refactoring
{

}
