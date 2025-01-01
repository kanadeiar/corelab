namespace ConsoleApp1.DDD.TicketAggregate.Common;

public class Escalate(string reason) : DomainEvent
{
    private readonly string _reason = reason;

    public string Reason => _reason;
}

public record EvaluateAtomicAction();