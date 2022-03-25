using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers;

[AutoValidateAntiforgeryToken]
public class HomeController : Controller
{
    private readonly DataContext _dataContext;
    private IEnumerable<Category> Categories => _dataContext.Categiries;
    private IEnumerable<Supplier> Suppliers => _dataContext.Suppliers;

    public HomeController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IActionResult Index()
    {
        var products = _dataContext.Products
            .Include(x => x.Category).Include(x => x.Suppliler);
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var p = await _dataContext.Products
            .Include(x => x.Category).Include(x => x.Suppliler)
            .FirstOrDefaultAsync(x => x.Id == id) ?? new Product();
        var model = ViewModelFactory.Details(p);
        return View("ProductEditor", model);
    }

    public IActionResult Create()
    {
        var model = ViewModelFactory.Create(new Product(), Categories, Suppliers);
        return View("ProductEditor", model);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Product product)
    {
        if (!ModelState.IsValid)
        {
            var model = ViewModelFactory.Create(new Product(), Categories, Suppliers);
            return View("ProductEditor", model);
        }
        product.Id = default;
        product.Category = default;
        product.Suppliler = default;
        _dataContext.Products.Add(product);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var p = await _dataContext.Products.FindAsync(id);
        if (p == null)
        {
            return NotFound();
        }
        var model = ViewModelFactory.Edit(p, Categories, Suppliers);
        return View("ProductEditor", model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] Product product)
    {
        if (!ModelState.IsValid)
        {
            var model = ViewModelFactory.Edit(product, Categories, Suppliers);
            return View("ProductEditor", model);
        }
        product.Category = default;
        product.Suppliler = default;
        _dataContext.Products.Update(product);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var p = await _dataContext.Products.FindAsync(id);
        if (p == null)
            return NotFound();
        var model = ViewModelFactory.Delete(p, Categories, Suppliers);
        return View("ProductEditor", model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] Product product)
    {
        _dataContext.Remove(product);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
