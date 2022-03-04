﻿using ConsoleApp1;
using GreenPipes;
using MassTransit;

var buscontrol = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("localhost");
    cfg.ReceiveEndpoint("invoke-service", e =>
    {
        e.UseInMemoryOutbox();
        e.UseMessageRetry(r => r.Interval(2, 100));
        e.Consumer<EventConsumer>();
    });
});
var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
await buscontrol.StartAsync(source.Token);
Console.WriteLine("Invoice Microservice Now Listening");

try
{
    while (true)
    {
        await Task.Delay(100);
    }
}
finally
{
    await buscontrol.StopAsync();
}

Console.WriteLine("Press any key");
Console.ReadKey();

