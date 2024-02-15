namespace ConsoleApp1.SenderModule.MessageFeat.NamesImpl;

public class NameSource
{
    private readonly Name _name;

    public NameSource(Name name)
    {
        _name = name;
    }

    public string Name => _name.Value;
}