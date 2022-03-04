using ClassLibrary1;
using ConsoleApp3;
using GreenPipes;
using MassTransit;

Console.WriteLine("Waiting customers initialize.");
await Task.Delay(3000);
var buscontrol = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("localhost");
    cfg.ReceiveEndpoint("invoke-service-created", e =>
    {
        e.UseInMemoryOutbox();
        e.UseMessageRetry(r => r.Interval(2, 100));
        e.Consumer<InvoiceCreatedConsumer>();
    });
});
var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
await buscontrol.StartAsync(source.Token);
var keyCount = 0;
try
{
    Console.WriteLine("Enter key to send message or Q to exit");

    while (Console.ReadKey().Key != ConsoleKey.Q)
    {
        keyCount++;
        await SendRequestForInvoiceCreation(buscontrol);
        Console.WriteLine("Enter key to send message or Q to exit {0}", keyCount);
    }
}
finally
{
    await buscontrol.StopAsync();    
}

Console.WriteLine("Press any key");
Console.ReadKey();

static async Task SendRequestForInvoiceCreation(IPublishEndpoint publishEndpoint)
{
    var rnd = new Random();
    await publishEndpoint.Publish<IInvoiceToCreate>(new
    {
        CustomerNumber = rnd.Next(1000, 9999),
        InvoiceItems = new List<InvoiceItems>()
        {
            new InvoiceItems{Description="Tables", Price=Math.Round(rnd.NextDouble()*100,2), 
                ActualMileage = 40, BaseRate = 12.50, IsHazarMaterials = false, IsOversized = true, IsRefrigerated = false},
            new InvoiceItems{Description="Chairs", Price=Math.Round(rnd.NextDouble()*100,2), 
                ActualMileage = 40, BaseRate = 12.50, IsHazarMaterials = false, IsOversized = false, IsRefrigerated = false}
        }
    });
}
