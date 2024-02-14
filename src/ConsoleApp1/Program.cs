using Kanadeiar.Common;

namespace ConsoleApp1;

public static class Program
{
    public static void Main(string[] args)
    {
        ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

        var address = ConsoleHelper.ReadLineFromConsole("Введите адрес");
        var name = ConsoleHelper.ReadLineFromConsole("Введите свои имя");
        
        Console.WriteLine();

        var service = new MailService();
        Message message = new Message();
        MessageBuilder buider = new MessageBuilder(message, name);
        var sender = new Sender(buider, service);
        sender.Send(address, "Програмное обеспечение приветствует программиста");

        ConsoleHelper.PrintFooter();
    }
}

