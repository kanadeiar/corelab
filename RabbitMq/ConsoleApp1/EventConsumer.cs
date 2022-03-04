using ClassLibrary1;
using MassTransit;

namespace ConsoleApp1;

public class EventConsumer : IConsumer<IInvoiceToCreate>
{
    public async Task Consume(ConsumeContext<IInvoiceToCreate> context)
    {
        var number = new Random().Next(10000, 99999);

        Console.WriteLine($"Creating invoice {number} for customer: {context.Message.CustomerNumber}");

        context.Message.InvoiceItems.ForEach(i => 
        {
            Console.WriteLine($"With items: Price: {i.Price}, Desc: {i.Description}");
            Console.WriteLine($"Actual distance in miles: {i.ActualMileage}, BaseRate: {i.BaseRate}");
            Console.WriteLine($"Oversized: {i.IsOversized}, Refrigerated:{i.IsRefrigerated}, Haz Mat: {i.IsHazarMaterials} ");
        });

        await context.Publish<IInvoiceCrated>(new 
        {
            InvoiceNumber = number,
            InvoiceData = new
            {
                context.Message.CustomerNumber,
                context.Message.InvoiceItems,
            }
        });
    }
}
