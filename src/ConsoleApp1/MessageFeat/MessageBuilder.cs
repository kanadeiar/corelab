namespace ConsoleApp1.MessageFeat;

public class MessageBuilder
{
    private string _clientName;
    private readonly Message _message;

    public MessageBuilder(Message message, string clientName)
    {
        _message = message;
        _clientName = clientName;
    }

    public string GetMessage(string text)
    {
        var hello = _message.HelloMessage(_clientName);
        var bye = _message.ByeMessage();

        var message = $"{hello}\n{text}\n{bye}";
        return message;
    }
}