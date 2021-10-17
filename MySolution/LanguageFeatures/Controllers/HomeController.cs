using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new string[] { "C#", "Java", "C++" });
        }
    }
}