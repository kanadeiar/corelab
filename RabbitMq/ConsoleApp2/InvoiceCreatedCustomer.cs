using ClassLibrary1;
using MassTransit;

namespace ConsoleApp2;

public class InvoiceCreatedCustomer : IConsumer<IInvoiceCrated>
{
    public async Task Consume(ConsumeContext<IInvoiceCrated> context)
    {
        await Task.Run(() => 
        {
            Console.WriteLine($"Receiver message from invoice: {context.Message.InvoiceNumber}");
        });
    }
}
