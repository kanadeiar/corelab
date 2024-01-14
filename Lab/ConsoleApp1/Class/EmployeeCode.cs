namespace ConsoleApp1.Class;

public class EmployeeCode
{
    public static EmployeeCode Engineer = new EmployeeCode(EmployeeType.Engineer);
    public static EmployeeCode Manager = new EmployeeCode(EmployeeType.Manager);
    private static readonly EmployeeCode[] _values = { Engineer, Manager };

    private readonly EmployeeType _code;

    private EmployeeCode(EmployeeType code)
    {
        _code = code;
    }
    public static EmployeeCode CreateCode(EmployeeType arg)
    {
        return _values.First(code => code._code == arg);
    }
}