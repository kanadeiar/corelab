using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace LanguageFeatures.Model
{
    class MyAsyncMethods
    {
        public async static Task<long?> GetPageLengthAsync()
        {
            var client = new HttpClient();
            var messsage = await client.GetAsync("http://apress.com");
            return messsage.Content.Headers.ContentLength;
        }
        public async static IAsyncEnumerable<long?> GetPageLengthsAsync(List<string> output, params string[] urls)
        {
            var client = new HttpClient();
            foreach (var url in urls)
            {
                output.Add($"Started request for {url}");
                var message = await client.GetAsync($"http://{url}");
                output.Add($"Completed reauest for {url}");
                yield return message.Content.Headers.ContentLength;
            }
        }
    }
}
