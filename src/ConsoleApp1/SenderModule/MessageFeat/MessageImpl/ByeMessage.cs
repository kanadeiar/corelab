namespace ConsoleApp1.SenderModule.MessageFeat.MessageImpl;

public class ByeMessage : Message
{
    public override string GetMessage(params string[] args)
    {
        return "До связи!";
    }
}