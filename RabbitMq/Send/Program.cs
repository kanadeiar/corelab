﻿using System;
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("RabbitMQ Application Send");
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "hello",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);
    string message = "Hello World!";
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "",
        routingKey: "hello",
        basicProperties: null,
        body: body);
    Console.WriteLine(" [x] Send {0}", message);
}

Console.WriteLine("Press key to exit ...");
Console.ReadKey();