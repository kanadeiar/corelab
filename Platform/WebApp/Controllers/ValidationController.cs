using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValidationController : ControllerBase
{
    private readonly DataContext _context;
    public ValidationController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("categoryId")]
    public bool CategoryKey(string? categoryId/*, [FromQuery] KeyTarget target*/)
    {
        return int.TryParse(categoryId /*?? target.CategoryId*/, out var keyVal) 
            && _context.Categiries.Find(keyVal) != null;
    }

    [HttpGet("supplierId")]
    public bool SupplierKey(string? supplierId/*, [FromQuery] KeyTarget target*/)
    {
        return int.TryParse(supplierId /*?? target.SupplierId*/, out var keyVal) 
            && _context.Suppliers.Find(keyVal) != null;
    }
}

//[Bind(Prefix = "Product")]
//public class KeyTarget
//{
//    public string CategoryId { get; set; }
//    public string SupplierId { get; set; }
//}
