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
}
