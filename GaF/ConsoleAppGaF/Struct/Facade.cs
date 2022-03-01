namespace ConsoleAppGaF.Struct;

public class Facade
{
    protected Subsystem1 _subsystem1;
    public Facade(Subsystem1 subsystem1)
    {
        _subsystem1 = subsystem1;
    }
    public string Operation()
    {
        string result = "Facade initializes subsystems:\n";
        result += _subsystem1.operation1();
        result += "Facade orders subsystems to perform the action:\n";
        result += _subsystem1.operationN();
        return result;
    }
}

public class Subsystem1
{
    public string operation1()
    {
        return "Subsystem1: Ready!\n";
    }
    public string operationN()
    {
        return "Subsystem1: Go!\n";
    }
}
