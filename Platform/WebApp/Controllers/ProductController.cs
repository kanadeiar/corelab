using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;

namespace WebApp.Controllers;

[ApiController, Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly DataContext _context;
    public ProductController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<ProductDTO>))]
    public IAsyncEnumerable<ProductDTO> GetProducts()
    {
        return _context.Products.Select(x => (ProductDTO)x).AsAsyncEnumerable();
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Nullable))]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is { })
        {
            return Ok((ProductDTO)product);
        }
        return NotFound();
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
    public async Task<IActionResult> SaveProduct(ProductDTO product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task UpdateProduct(ProductDTO product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
    [HttpPatch("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Nullable))]
    public async Task<ProductDTO> PatchProduct(int id, JsonPatchDocument<Product> patchDocument)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is { })
        {
            patchDocument.ApplyTo(product);
            await _context.SaveChangesAsync();
            return (ProductDTO)product;
        }
        return default;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task DeleteProduct(int id)
    {
        _context.Products.Remove(new Product {Id = id});
        await _context.SaveChangesAsync();
    }
    [HttpGet("redirect")]
    public IActionResult Redirect()
    {
        return RedirectToAction(nameof(GetProduct), new { id = 1 });
    }
}
