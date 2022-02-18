namespace SportStore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}