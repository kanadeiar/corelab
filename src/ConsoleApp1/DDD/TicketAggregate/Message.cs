namespace ConsoleApp1.DDD.TicketAggregate;

public class Message(PersonId from, string body)
{
    private PersonId _to;

    private bool _wasRead;

    public bool WasNotRead(PersonId id) => _to == id && !_wasRead;
}