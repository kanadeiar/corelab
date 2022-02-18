namespace SportStore.Controllers;

public class HomeController : Controller
{
    private IStoreRepository _repo;
    public HomeController(IStoreRepository repo)
    {
        _repo = repo;
    }
    public IActionResult Index()
    {
        var models = _repo.Products.ToArray();
        return View(models);
    }
}