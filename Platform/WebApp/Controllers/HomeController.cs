using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using WebApp.Data;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(int id = 1)
    {
        var product = await _context.Products.FindAsync(id);
        ViewBag.AveragePrice = await _context.Products.AverageAsync(x => x.Price);
        return View(product);
    }
    public IActionResult List()
    {
        return View(_context.Products);
    }
    public IActionResult CubedShow()
    {
        return View("Cubed");
    }
    public IActionResult Cube(double num)
    {
        TempData["value"] = num.ToString();
        TempData["result"] = Math.Pow(num, 3).ToString();
        return RedirectToAction("CubedShow");
    }
}
