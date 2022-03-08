using MassTransit;
using Test.Core.Contracts;
using Test.Core.Models;

namespace Response.Consumers;

public class ProductInfoRequestConsumer : IConsumer<ProductInfoRequest>
{
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

        await context.RespondAsync(new ProductInfoResponse
        {
            Product = p
        });
    }
}
