
internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Приложение опытное для исследований асинхронности");

        await Task.Delay(1000);

        var client = new HttpClient();
        var page = await client.GetStringAsync(@"https://nigma.net.ru/");
        Console.WriteLine($@"Page:\n{page}");

        Console.WriteLine("Нажать любую кнопку для продолжения ...");
        var _ = Console.ReadKey();
    }
}



