using System;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleAppAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лаборатория асинхронного кода");

            DumpWebPageAsync("https://yandex.ru/");

            Console.Title = "Завершено";
            Console.WriteLine("Нажмите любую кнопку для закрытия ...");
            Console.ReadLine();
        }

        static async Task DumpWebPageAsync(string uri)
        {
            var client = new WebClient();
            var page = await client.DownloadStringTaskAsync(uri);
            Console.WriteLine(page);
        }
    }
}
