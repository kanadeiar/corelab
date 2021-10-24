using System.Threading.Tasks;
using System.Net.Http;

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
    }
}
