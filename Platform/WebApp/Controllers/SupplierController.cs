using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers;

[ApiController, Route("api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly DataContext _context;
    public SupplierController(DataContext context)
    {
        _context = context;
    }
    [HttpGet("{id}")]
    public async Task<Supplier?> GetSupplier(int id)
    {
        var supplier = await _context.Suppliers
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (supplier is { })
        {
            foreach (var p in supplier.Products)
            {
                p.Suppliler = null;
            }
            return supplier;
        }
        return null;
    }
    [HttpPatch("{id}")]
    public async Task<Supplier?> PatchSupplier(int id, JsonPatchDocument<Supplier> patchDocument)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier is { })
        {
            patchDocument.ApplyTo(supplier);
            await _context.SaveChangesAsync();
        }
        return supplier;
    }
}
