using ClassLibrary1;
using MassTransit;

namespace ConsoleApp3;

public class InvoiceCreatedConsumer : IConsumer<IInvoiceCrated>
{
    public async Task Consume(ConsumeContext<IInvoiceCrated> context)
    {
        await Task.Run(() =>
        {
            Console.WriteLine($"Invoice with number: {context.Message.InvoiceNumber} created.");
        });
    }
}
