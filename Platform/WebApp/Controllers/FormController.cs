using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers;

[AutoValidateAntiforgeryToken]
public class FormController : Controller
{
    private readonly DataContext _dataContext;
    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index([FromQuery] int? id)
    {
        ViewBag.Categories = new SelectList(_dataContext.Categiries, "Id", "Name");
        var product = await _dataContext.Products
            .Include(x => x.Suppliler).Include(x => x.Category).FirstOrDefaultAsync(x => id == null || x.Id == id);
        return View("Form", product);
    }

    //[HttpPost]
    //public IActionResult SubmitForm(Product product)
    //{
    //    TempData["product"] = System.Text.Json.JsonSerializer.Serialize(product);
    //    return RedirectToAction(nameof(Results));
    //}

    [HttpPost]
    public IActionResult SubmitForm([Bind("Name", "Category")] Product product)
    {
        TempData["name"] = product.Name;
        TempData["price"] = product.Price.ToString();
        TempData["category name"] = product.Category.Name;
        return RedirectToAction(nameof(Results));
    }

    public IActionResult Results()
    {
        return View();
    }
}
