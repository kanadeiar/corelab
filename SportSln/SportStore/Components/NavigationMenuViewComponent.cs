namespace SportStore.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IStoreRepository _repo;
    public NavigationMenuViewComponent(IStoreRepository repo)
    {
        _repo = repo;
    }
    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        var categories = _repo.Products
            .Select(x => x.Category)
            .Distinct().OrderBy(x => x);
        return View(categories);
    }
}