namespace ConsoleApp1.DDD.TicketAggregate.Commands;

public record AddMessage(PersonId From, string Body);