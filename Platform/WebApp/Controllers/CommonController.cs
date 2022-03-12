using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CommonController : Controller
{
    public IActionResult Index()
    {
        return View("Common");
    }
}
