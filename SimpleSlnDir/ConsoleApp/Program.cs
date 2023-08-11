using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Handler(float value)
        {
            Console.WriteLine("Прогресс " + value.ToString("F"));
        }

        public static async Task Main(string[] args)
        {
            var urls = new[] { @"https://nigma.net.ru/", @"https://mail.ru/", @"https://ya.ru" };
            Console.WriteLine("Приложение опытное для исследований асинхронности");

            var source = new CancellationTokenSource();

            Task.Run(async () =>
            {
                var progress = new Progress<float>(Handler);
                var pages = await Sample.GetPages(urls, source.Token, progress);
                foreach (var p in pages)
                {
                    Console.WriteLine("page len: " + p.Length);
                }
            });

            //var tasks = urls.Select(x => GetPage(x, source.Token)).ToArray();
            //Task.Run(async () =>
            //{
            //    //var pages = await Task.WhenAll(tasks);
            //    //for (int i = 0; i < pages.Length; i++)
            //    //{
            //    //    Console.WriteLine($"page {urls[i]}:  {pages[i].Length}");
            //    //}
            //    var winner = await Task.WhenAny(tasks);
            //    var page = await winner;
            //    Console.WriteLine($"page: {page.Length}");
            //    foreach (var t in tasks)
            //    {
            //        if (winner != t)
            //        {
            //            await t;
            //        }
            //    }
            //});

            Console.WriteLine("Нажать кнопку для отмены");
            Console.ReadKey();
            source.Cancel();

            Console.WriteLine("Нажать любую кнопку для продолжения ...");
            var _ = Console.ReadKey();
        }


    }
}







