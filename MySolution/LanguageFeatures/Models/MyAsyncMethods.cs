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
        public async static Task<IEnumerable<long?>> GetPageLengthsAsync(List<string> output, params string[] urls)
        {
            var results = new List<long?>();
            var client = new HttpClient();
            foreach (var url in urls)
            {
                output.Add($"Started request for {url}");
                var message = await client.GetAsync($"http://{url}");
                results.Add(message.Content.Headers.ContentLength);
                output.Add($"Completed reauest for {url}");
            }
            return results;
        }
    }
}
