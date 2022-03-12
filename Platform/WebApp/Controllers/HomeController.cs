using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Index(int id = 1)
    {
        var product = await _context.Products.FindAsync(id);
        if (product?.CategoryId == 1)
        {
            return View("Watersports", product);
        }
        else
        {
            return View(product);
        }
    }
    public IActionResult Common()
    {
        return View();
    }
    public IActionResult List()
    {
        return View(_context.Products);
    }
}
