namespace ConsoleApp1.SenderModule;

public class Sender
{
    private readonly IMessageBuilder _builder;
    private readonly IMailService _mail;

    public Sender(IMessageBuilder builder, IMailService mail)
    {
        _builder = builder;
        _mail = mail;
    }

    public bool Send(string address, string message)
    {
        var text = _builder.GetMessage(message);
        _mail.SendToMail(address, text);
        return true;
    }
}