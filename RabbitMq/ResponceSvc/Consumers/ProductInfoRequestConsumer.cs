using Contracts;
using Contracts.Contracts;
using MassTransit;
using System.Threading.Tasks;

namespace ResponceSvc.Consumers
{
    public class ProductInfoRequestConsumer
        : IConsumer<ProductInfoRequest>
    {
        public async Task Consume(ConsumeContext<ProductInfoRequest> context)
        {
            var msg = context.Message;
            var slug = msg.Slug;

            // a fake delay
            var delay = 1000 * (msg.Delay > 0 ? msg.Delay : 1);
            await Task.Delay(delay);

            // get the product from ProductService
            var p = new Product { Name = "PS4", Slug = "g-ps4", Description = "The PlayStation 4 is an eighth-generation home video game console developed by Sony Computer Entertainment. Announced as the successor to the PlayStation 3 in February 2013, it was launched on November 15 in North America, November 29 in Europe, South America and Australia, and on February 22, 2014 in Japan.", Price = 299 };

            // this responds via the queue to our client
            await context.RespondAsync(new ProductInfoResponse
            {
                Product = p
            });
        }
    }
}
