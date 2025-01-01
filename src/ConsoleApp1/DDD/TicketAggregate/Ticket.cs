using ConsoleApp1.DDD.TicketAggregate.Commands;
using ConsoleApp1.DDD.TicketAggregate.Common;

namespace ConsoleApp1.DDD.TicketAggregate;

public class Ticket
{
    private TicketId _id;
    private int _version;
    private string _reason;
    private bool _isEscalated;

    private List<DomainEvent> _domainEvents;

    private Messages _messages = new();

    private PersonId Customer { get; set; }

    private IList<ProductId> Products { get; } = new List<ProductId>();

    private PersonId Agent { get; set; }

    public void Execute(AddMessage cmd)
    {
        var message = new Message(cmd.From, cmd.Body);
        _messages.Add(message);
    }

    public void Execute(Escalate cmd)
    {
        _reason = cmd.Reason;
        _version++;
    }

    public void Execute(EvaluateAtomicAction cmd)
    {
        var escalatedEvent = new Escalate("one");
        _domainEvents.Add(escalatedEvent);
    }
}

public record TicketId(int id);