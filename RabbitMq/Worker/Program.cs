using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

Console.WriteLine("RabbitMQ Application Worker");
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "task_queue",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

    Console.WriteLine(" [*] Waiting for messages.");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (o, e) =>
    {
        byte[] body = e.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine(" [0] reveiced {0}", message);

        int dots = message.Split('.').Length - 1;
        Thread.Sleep(dots * 1000);

        Console.WriteLine(" [x] Done");

        channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
    };
    channel.BasicConsume(queue: "task_queue",
        autoAck: false,
        consumer: consumer);
    Console.WriteLine("Press key to exit ...");
    Console.ReadKey();
}


