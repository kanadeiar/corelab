namespace ConsoleApp1.SenderModule.MessageFeat.MessageImpl;

public class HelloMessage : Message
{
    public override string GetMessage(params string[] args)
    {
        return $"Привет, {args.First()}!";
    }
}