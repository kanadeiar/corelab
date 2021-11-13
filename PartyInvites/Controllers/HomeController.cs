namespace PartyInvites.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RsvpForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RsvpForm(GuestResponse model)
    {
        if (!ModelState.IsValid)
            return View();
        Repository.AddResponse(model);
        return View("Thanks", model);
    }

    public IActionResult ListResponses()
    {
        var model = Repository.Responses.Where(r => r.WillAttend == true);
        return View(model);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
