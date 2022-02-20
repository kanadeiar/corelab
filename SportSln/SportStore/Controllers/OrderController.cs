namespace SportStore.Controllers;

public class OrderController : Controller
{
    private IOrderRepository _repository;
    private Cart _cart;
    public OrderController(IOrderRepository repoService, Cart cartService)
    {
        _repository = repoService;
        _cart = cartService;
    }
    public IActionResult Checkout()
    {
        var model = new Order();
        return View(model);
    }
    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (!_cart.Lines.Any())
        {
            ModelState.AddModelError("", "Sorry, your cart is empty!");
        }
        if (ModelState.IsValid)
        {
            order.Lines = _cart.Lines.ToArray();
            _repository.SaveOrder(order);
            _cart.Clear();
            return RedirectToAction("Completed", "Order", new { id = order.Id });
        }
        return View();
    }
    public IActionResult Completed(int Id)
    {        
        return View(Id);
    }
}