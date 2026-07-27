namespace ConsoleApp1;

public static class Program
{
    public static void Main()
    {
        ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

        var name = ConsoleHelper.ReadLineFromConsole("Введите свое имя");
        var surName = ConsoleHelper.ReadLineFromConsole("Введите свою фамилию");

        ConsoleHelper.Print($"Привет, {surName} {name}!");

        ConsoleHelper.PrintFooter();
    }
}

