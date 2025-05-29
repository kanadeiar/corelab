namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main()
        {
            ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            ConsoleHelper.PrintFooter();
        }
    }
}

