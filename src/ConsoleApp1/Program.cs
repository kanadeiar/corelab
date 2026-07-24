namespace ConsoleApp1;

public static class Program
{
    public static void Main()
    {
        ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

        var name = ConsoleHelper.ReadLineFromConsole("Введите свое имя");

        ConsoleHelper.Print($"Привет, {name}!");

        ConsoleHelper.PrintFooter();
    }
}

