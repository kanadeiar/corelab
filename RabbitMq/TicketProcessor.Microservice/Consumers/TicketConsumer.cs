using MassTransit;
using Shared.Models;

namespace TicketProcessor.Microservice.Consumers;

public class TicketConsumer : IConsumer<Ticket>
{
    private readonly ILogger<TicketConsumer> _logger;
    public TicketConsumer(ILogger<TicketConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<Ticket> context)
    {
        var data = context.Message;
        _logger.LogInformation("data: {0} {1} {2}", data.UserName, data.Destination, data.Boarding);
    }
}
