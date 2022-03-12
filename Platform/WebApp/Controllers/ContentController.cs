using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers;

[ApiController, Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly DataContext _context;
    public ContentController(DataContext context)
    {
        _context = context;
    }
    [HttpGet("string")]
    public string GetString() => "This is string";
    [HttpGet("object")]
    public async Task<Product> GetObject()
    {
        var product = await _context.Products.FirstAsync();
        return product;
    }
}
