namespace ConsoleApp1.SenderModule.MessageFeat;

public class MessageBuilder : IMessageBuilder
{
    private MessagesCollection _collection;

    private MessageBuilder(NameSource source)
    {
        _collection = MessagesCollection.Create(source);
    }

    public static MessageBuilder Create(NameSource source)
    {
        return new MessageBuilder(source);
    }

    public string GetMessage(string text)
    {
        var hello = _collection.Get(MessageCode.Hello);
        var bye = _collection.Get(MessageCode.Bye);

        var message = $"{hello}\n{text}\n{bye}";
        return message;
    }
}