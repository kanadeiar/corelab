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
            //var output = new List<string>();
            //await foreach (var len in MyAsyncMethods.GetPageLengthsAsync(output, "apress.com", "microsoft.com", "amazon.com"))
            //{
            //    output.Add($"Page length: {len}");
            //}
            //return View(output);
            var products = new[]
            {
                new { Name = "Каяк", Price = 275M },
                new { Name = "Флак", Price = 48.1M },
                new { Name = "Черн", Price = 19.5M },
                new { Name = "Посл", Price = 34.95M },
            };
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }
    }
}