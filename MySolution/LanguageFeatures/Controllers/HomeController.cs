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
            long? length = await MyAsyncMethods.GetPageLengthAsync();
            return View(new string[] { $"Lenght: {length}" });
        }
    }
}