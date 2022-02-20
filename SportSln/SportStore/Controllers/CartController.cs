namespace SportStore.Controllers;

public class CartController : Controller
{
    private IStoreRepository _repo;
    private Cart _cart;
    public CartController(IStoreRepository repo, Cart cartService)
    {
        _repo = repo;
        _cart = cartService;
    }
    public IActionResult Index(string returnUrl)
    {
        var model = new CartWebModel
        {
            Cart = _cart,
            ReturnUrl = returnUrl ?? "/",
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Index(long Id, string returnUrl)
    {
        var product = _repo.Products.FirstOrDefault(x => x.Id == Id);
        _cart.AddItem(product, 1);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }
    [HttpPost]
    public IActionResult Remove(long Id, string returnUrl)
    {
        _cart.RemoveLine(_cart.Lines.First(x => x.Product.Id == Id).Product);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }
}