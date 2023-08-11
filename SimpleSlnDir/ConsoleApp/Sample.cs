using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Sample
    {
        public static async Task<IEnumerable<string>> GetPages(IEnumerable<string> urls, CancellationToken token = default,
            IProgress<float>? progress = default)
        {
            var pages = new List<string>();
            var current = 0.0f;
            var step = 100.0f / urls.Count();
            var us = urls as string[] ?? urls.ToArray();
            foreach (var url in us.ToArray())
            {
                progress?.Report(current += step);
                token.ThrowIfCancellationRequested();
                var task = GetPage(url, token);
                pages.Add(await task);
            }
            return pages;
        }

        public static async Task<string> GetPage(string url, CancellationToken token = default)
        {
            var client = new HttpClient();
            var page = await client.GetStringAsync(url, token);
            return page;
        }
    }
}
