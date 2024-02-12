using Kanadeiar.Common;

namespace ConsoleApp1;

public static class Program
{
    public static void Main(string[] args)
    {
        ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

        var name = ConsoleHelper.ReadLineFromConsole("Введите свои имя");
        Console.WriteLine();

        var message = new Message();
        var buider = new MessageBuilder(message, name);

        var text = buider.GetMessage("Програмное обеспечение приветствует программиста");

        Console.WriteLine(text);

        ConsoleHelper.PrintFooter();
    }
}

