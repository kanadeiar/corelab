namespace ConsoleApp1;

public class Programmer
{
    private readonly string _name;

    public string Name
    {
        get => _name;
    }

    protected Programmer(string name)
    {
        _name = name;
    }

    public static Programmer CreateInstance(string type, string name)
    {
        switch (type)
        {
            case "junior":
                return new Junior(name);
            case "middle":
                return new Middle(name);
            default:
                throw new IndexOutOfRangeException();
        }
    }
}