namespace ConsoleApp1.SenderModule.MessageFeat;

public class MessageBuilder : IMessageBuilder
{
    private readonly string _clientName;
    private readonly Message _message;

    public string ClientName => _clientName;

    public MessageBuilder(Message message, string clientName)
    {
        _message = message;
        _clientName = clientName;
    }

    public string GetMessage(string text)
    {
        var hello = _message.HelloMessage(ClientName);
        var bye = _message.ByeMessage();

        var message = $"{hello}\n{text}\n{bye}";
        return message;
    }
}