using System;
using System.Net;

namespace ConsoleAppAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лаборатория асинхронного кода");

            DumpWebPage("https://yandex.ru/");

            Console.Title = "Завершено";
            Console.WriteLine("Нажмите любую кнопку для закрытия ...");
            Console.ReadLine();
        }

        private static void DumpWebPage(string uri)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += OnDownloadStringCompleted;
            client.DownloadStringAsync(new Uri(uri));
        }

        private static void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs args)
        {
            Console.WriteLine(args.Result);
        }
    }
}
