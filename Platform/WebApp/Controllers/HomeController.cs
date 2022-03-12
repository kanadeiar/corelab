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
    public async Task<IActionResult> Index(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return View(product);
    }
}
