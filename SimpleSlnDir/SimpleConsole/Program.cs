
internal class Program
{
    private static async Task Main(string[] args)
    {
        System.Console.WriteLine("Заголовок программы");
        await Task.Delay(3000);
        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.ReadKey();
    }
}