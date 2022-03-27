using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages;

public class EditorPageModel : PageModel
{
    public readonly DataContext DataContext;
    public ProductWebModel WebModel { get; set; }
    public IEnumerable<Category> Categories => DataContext.Categiries;
    public IEnumerable<Supplier> Suppliers => DataContext.Suppliers;
    public EditorPageModel(DataContext dataContext)
    {
        DataContext = dataContext;
    }
    protected async Task CheckNewCategory(Product product)
    {
        if (product.CategoryId == -1 && !string.IsNullOrEmpty(product.Category?.Name))
        {
            DataContext.Categiries.Add(product.Category);
            await DataContext.SaveChangesAsync();
            product.CategoryId = product.Category.Id;
            ModelState.Clear();
            TryValidateModel(product);
        }
    }
}
