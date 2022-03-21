using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace WebApp.Controllers;

[AutoValidateAntiforgeryToken]
public class FormController : Controller
{
    private readonly DataContext _dataContext;
    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index(int? id)
    {
        ViewBag.Categories = new SelectList(_dataContext.Categiries, "Id", "Name");
        var product = await _dataContext.Products
            .Include(x => x.Suppliler).Include(x => x.Category).FirstOrDefaultAsync(x => id == null || x.Id == id);
        return View("Form", product);
    }

    [HttpPost]
    public IActionResult SubmitForm(string name, decimal price)
    {
        TempData["name price"] = name;
        TempData["price param"] = price.ToString();
        return RedirectToAction(nameof(Results));
    }

    public IActionResult Results()
    {
        return View();
    }
}
