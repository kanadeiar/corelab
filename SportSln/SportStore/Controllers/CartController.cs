using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using SportStore.Infrastructure;
using SportStore.Models;
using System.Linq;

namespace SportStore.Controllers;

public class CartController : Controller
{
    private IStoreRepository _repo;
    public CartController(IStoreRepository repo)
    {
        _repo = repo;
    }
    public IActionResult Index(string returnUrl)
    {
        var model = new CartWebModel
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(),
            ReturnUrl = returnUrl ?? "/",
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Index(long Id, string returnUrl)
    {
        var product = _repo.Products.FirstOrDefault(x => x.Id == Id);
        var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        cart.AddItem(product, 1);
        HttpContext.Session.SetJson("cart", cart);
        return RedirectToAction("Index", new { returnUrl = returnUrl });
    }
}