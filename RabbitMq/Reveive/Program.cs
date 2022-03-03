using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

Console.WriteLine("RabbitMQ Application Reveive");
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "hello",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (o, e) =>
    {
        var body = e.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine(" [0] reveiced {0}", message);
    };
    channel.BasicConsume(queue: "hello",
        autoAck: true,
        consumer: consumer);
    Console.WriteLine("Press key to exit ...");
    Console.ReadKey();
}

