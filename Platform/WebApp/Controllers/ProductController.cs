using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController, Route("api/{controller}")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IAsyncEnumerable<ProductDTO> GetProducts()
        {
            return _context.Products.Select(x => (ProductDTO)x).AsAsyncEnumerable();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is { })
            {
                return Ok(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDTO product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpPut]
        public async Task UpdateProduct(ProductDTO product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        [HttpDelete("{id}")]
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
}
