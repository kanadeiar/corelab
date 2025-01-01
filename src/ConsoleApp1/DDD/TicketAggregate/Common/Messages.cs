namespace ConsoleApp1.DDD.TicketAggregate.Common;

public class Messages
{
    private List<Message> _messages = new List<Message>();

    public void Add(Message message)
    {
        _messages.Add(message);
    }

    public int GetUnreadMessagesCount(PersonId id)
    {
        return _messages.Count(m => m.WasNotRead(id));
    }
}