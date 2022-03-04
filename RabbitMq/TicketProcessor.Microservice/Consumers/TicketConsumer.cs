using MassTransit;
using Shared.Models;

namespace TicketProcessor.Microservice.Consumers;

public class TicketConsumer : IConsumer<ICheckTicketRequest>
{
    private static List<Ticket> _tickets = new List<Ticket>();
    private readonly ILogger<TicketConsumer> _logger;
    public TicketConsumer(ILogger<TicketConsumer> logger)
    {
        _logger = logger;
        _tickets = Enumerable.Range(1, 10).Select(i => new Ticket
        {
            Id = i,
            UserName = $"user{i}",
            Destination = $"test{i}",
            Boarding = "",
            BookedOn = DateTime.Now,
        }).ToList();
    }
    //public async Task Consume(ConsumeContext<Ticket> context)
    //{
    //    var data = context.Message;
    //    _logger.LogInformation("data: {0} {1} {2}", data.UserName, data.Destination, data.Boarding);
    //}
    public async Task Consume(ConsumeContext<ICheckTicketRequest> context)
    {
        if (context.Message.Id > 0 && context.Message.Id < _tickets.Count)
        {
            var ticket = _tickets[context.Message.Id];
            await context.RespondAsync<ICheckTicketRequest>(new
            {
                Id = ticket.Id,
                UserName = ticket.UserName,
                BookedOn = ticket.BookedOn,
                Boarding = ticket.Boarding,
                Destination = ticket.Destination,
            });
        }
    }
}
