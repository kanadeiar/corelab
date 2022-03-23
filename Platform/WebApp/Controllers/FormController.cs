using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IActionResult> Index(int? id)
    {
        var product = await _dataContext.Products.FirstOrDefaultAsync(x => id == null || x.Id == id);
        return View("Form", product);
    }

    [HttpPost]
    public IActionResult SubmitForm(Product product)
    {
        //if (string.IsNullOrEmpty(product.Name))
        //{
        //    ModelState.AddModelError(nameof(Product.Name), "Введите имя");
        //}
        //if (ModelState.GetValidationState(nameof(Product.Price)) == ModelValidationState.Valid && product.Price < 1)
        //{
        //    ModelState.AddModelError(nameof(Product.Price), "Введите положительную цену");
        //}
        if (ModelState.GetValidationState(nameof(Product.Name)) == ModelValidationState.Valid 
            && ModelState.GetValidationState(nameof(Product.Price)) == ModelValidationState.Valid
            && product.Name.ToLower().StartsWith("small")
            && product.Price > 100)
        {
            ModelState.AddModelError("", "Маленькие продукты не могуть стоить выше 100");
        }
        if (!_dataContext.Categiries.Any(x => x.Id == product.CategoryId))
        {
            ModelState.AddModelError(nameof(Product.CategoryId), "Введите идентификатор соответствующей категории");
        }
        if (!_dataContext.Suppliers.Any(x => x.Id == product.SupplierId))
        {
            ModelState.AddModelError(nameof(Product.SupplierId), "Введите идентификатор соответствующего поставщика");
        }
        if (ModelState.IsValid)
        {
            TempData["name"] = product.Name;
            TempData["price"] = product.Price.ToString();
            TempData["categoryId"] = product.CategoryId.ToString();
            TempData["supplierId"] = product.SupplierId.ToString();
            return RedirectToAction(nameof(Results));
        }
        else
        {
            return View("Form");
        }
    }

    public IActionResult Results()
    {
        return View();
    }
}
