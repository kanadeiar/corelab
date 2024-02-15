namespace ConsoleApp1.SenderModule.MessageFeat.MessageImpl;

internal class MessagesCollection
{
    private readonly NameSource _source;
    private Dictionary<MessageCode, Message> _messages = new();

    private MessagesCollection(NameSource source)
    {
        _source = source;
        initMessages();
    }

    public static MessagesCollection Create(NameSource source)
    {
        return new MessagesCollection(source);
    }

    private void initMessages()
    {
        _messages.Add(MessageCode.Hello, MessagesFactory.Create(MessageCode.Hello));
        _messages.Add(MessageCode.Bye, MessagesFactory.Create(MessageCode.Bye));
    }

    public Message Get(MessageCode code) => _messages[code];
}