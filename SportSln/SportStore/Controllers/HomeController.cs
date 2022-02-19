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
        var model = new ProductListWebModel
        {
            Products = _repo.Products
                .OrderBy(x => x.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize).ToArray(),
            PagingInfo = new PagingInfoWebModel
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = _repo.Products.Count(),
            }
        };
        return View(model);
    }
}