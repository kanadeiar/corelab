using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

Console.WriteLine("RabbitMQ Application NewTask");
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "hello",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    var message = GetMessage(args);
    var body = Encoding.UTF8.GetBytes(message);

    var prorerties = channel.CreateBasicProperties();
    prorerties.Persistent = true;

    channel.BasicPublish(exchange: "",
        routingKey: "task_queue",
        basicProperties: prorerties,
        body: body);
    Console.WriteLine(" [x] Send {0}", message);
}

Console.WriteLine("Press key to exit ...");
Console.ReadKey();







static string GetMessage(string[] args)
{
    return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
}