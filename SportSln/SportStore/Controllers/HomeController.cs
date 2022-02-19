namespace SportStore.Controllers;

public class HomeController : Controller
{
    private IStoreRepository _repo;
    public int PageSize = 4;
    public HomeController(IStoreRepository repo)
    {
        _repo = repo;
    }
    public IActionResult Index(string category, int page = 1)
    {
        var query = _repo.Products
            .Where(x => category == null || x.Category == category)
            .OrderBy(x => x.Id);
        var model = new ProductListWebModel
        {
            Products = query.Skip((page - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfoWebModel
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = query.Count(),
            },
            CurrentCategory = category,
        };
        return View(model);
    }
}