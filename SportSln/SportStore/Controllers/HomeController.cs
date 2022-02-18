namespace SportStore.Controllers;

public class HomeController : Controller
{
    private IStoreRepository _repo;
    public int PageSize = 4;
    public HomeController(IStoreRepository repo)
    {
        _repo = repo;
    }
    public IActionResult Index(int page = 1)
    {
        var models = _repo.Products
            .OrderBy(x => x.Id)
            .Skip((page - 1) * PageSize)
            .Take(PageSize).ToArray();
        return View(models);
    }
}