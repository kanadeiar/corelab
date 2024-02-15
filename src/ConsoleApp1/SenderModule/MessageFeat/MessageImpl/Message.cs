namespace ConsoleApp1.SenderModule.MessageFeat.MessageImpl;

public abstract class Message
{
    public abstract string GetMessage(params string[] args);
}