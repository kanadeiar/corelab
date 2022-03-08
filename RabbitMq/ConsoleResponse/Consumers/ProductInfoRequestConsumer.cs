using MassTransit;
using Microsoft.Extensions.Logging;
using Test.Core.Contracts;
using Test.Core.Models;

namespace ConsoleResponse.Consumers;

public class ProductInfoRequestConsumer : IConsumer<ProductInfoRequest>
{
    private readonly ILogger<ProductInfoRequestConsumer> _logger;
    public ProductInfoRequestConsumer(ILogger<ProductInfoRequestConsumer> logger)
    {
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<ProductInfoRequest> context)
    {
        var msg = context.Message;
        var slug = msg.Slug;

        var p = new Product()
        {
            Slug = slug,
            Name = "Test Product",
            Description = "Test Description",
            Price = 300,
        };
        _logger.LogInformation($"Response for request: {slug}");

        await context.RespondAsync(new ProductInfoResponse
        {
            Product = p
        });
    }
}
