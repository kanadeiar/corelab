namespace ConsoleApp1;

public static class Program
{
    public static void Main(string[] args)
    {
        ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

        var add = (int x, int y) => x + y;

        var res = add(2, 3);



        ConsoleHelper.PrintFooter();
    }
}


