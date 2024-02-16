using System.Globalization;
using System.Numerics;
using static System.Console;

namespace Kanadeiar.Common;

public class ConsoleHelper
{
    public static void PrintHeader(string title = "Приложение", string text = "Название приложения")
    {
        setupConsole(title);
        outputHeaderToConsole(text);
    }

    private static void outputHeaderToConsole(string text)
    {
        BackgroundColor = ConsoleColor.DarkGreen;
        ForegroundColor = ConsoleColor.White;

        WriteLine($"┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
        WriteLine($"│{text,-117}│");
        WriteLine($"└─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");

        ForegroundColor = ConsoleColor.White;
        BackgroundColor = ConsoleColor.Black;

        WriteLine("");
    }

    private static void setupConsole(string title)
    {
        Title = title;
        WindowWidth = 120;
    }

    public static void PrintFooter(string text = "Для выхода нажмите любую кнопку ...")
    {
        WriteLine("\n" + text);
        ReadKey();
    }

    public static void Pause(string text = "Нажмите любую кнопку для продолжения ...")
    {
        WriteLine("\n" + text);
        ReadKey();
    }

    public static void PositionPrint(string message, int x, int y)
    {
        SetCursorPosition(x, y);
        WriteLine(message);
    }

    public static string? ReadLineFromConsole(string message)
    {
        Write($"{message}:>");
        return ReadLine();
    }

    public static T ReadNumberFromConsole<T>(string message)
        where T : INumber<T>
    {
        while (true)
        {
            Write($"{message}:>");
            var ci = new CultureInfo("ru-ru");
            if (T.TryParse(ReadLine(), ci, out T? number))
            {
                return number;
            }
            WriteLine("Ошибка! Введен неверный формат числа!");

            Beep();
        }
    }
}