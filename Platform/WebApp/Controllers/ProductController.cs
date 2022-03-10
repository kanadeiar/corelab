using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/{controller}")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return new Product[] { new Product { Name = "Test1" }, new Product { Name = "Test2" } };
        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return new Product { Name = string.Concat("Test_", id.ToString()) };
        }
    }
}
