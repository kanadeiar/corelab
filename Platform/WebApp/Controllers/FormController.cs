using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace WebApp.Controllers;

public class FormController : Controller
{
    private readonly DataContext _dataContext;
    public FormController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index(int id = 1)
    {
        var product = await _dataContext.Products.Include(x => x.Suppliler).Include(x => x.Category).FirstAsync(x => x.Id == id);
        return View("Form", product);
    }

    [HttpPost]
    public IActionResult SubmitForm()
    {
        foreach (var item in Request.Form.Keys.Where(k => !k.StartsWith("_")))
        {
            TempData[item] = string.Join(", ", Request.Form[item]);
        }
        return RedirectToAction(nameof(Results));
    }

    public IActionResult Results()
    {
        return View();
    }
}
