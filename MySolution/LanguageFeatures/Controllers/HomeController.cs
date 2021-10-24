using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var output = new List<string>();
            await foreach (var len in MyAsyncMethods.GetPageLengthsAsync(output, "apress.com", "microsoft.com", "amazon.com"))
            {
                output.Add($"Page length: {len}");
            }
            return View(output);
        }
    }
}