namespace ConsoleAppGaF.Behavior;

interface ICommand
{
    void Execute();
}

class SimpleCommand : ICommand
{
    private readonly string _payload;
    public SimpleCommand(string payload)
    {
        _payload = payload;
    }
    public void Execute()
    {
        Console.WriteLine($"SimpleCommand: See {_payload}");
    }
}

class Invoker
{
    private ICommand _onStart;
    private ICommand _onStop;
    public void SetOnStart(ICommand command)
    {
        _onStart = command;
    }
    public void SetOnStop(ICommand command)
    {
        _onStop = command;
    }
    public void Invoke()
    {
        if (_onStart is ICommand)
            _onStart.Execute();
        if (_onStop is ICommand)
            _onStop.Execute();
    }
}
