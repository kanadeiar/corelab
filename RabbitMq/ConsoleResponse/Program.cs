using ConsoleResponse.Consumers;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                var host = "rabbitmq://localhost";
                var queue = "responsesvc";
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<ProductInfoRequestConsumer>();

                    x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
                    {
                        c.Host(host);                        
                        c.ReceiveEndpoint(queue, e =>
                        {
                            e.PrefetchCount = 16;
                            e.UseMessageRetry(r => r.Interval(2, 3000));
                            e.Consumer<ProductInfoRequestConsumer>(context);
                        });
                    }));
                });
                services.AddMassTransitHostedService();
            });
}


