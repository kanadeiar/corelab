

namespace Simple.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public static Product[] GetProducts()
        {
            var kayak = new Product { Name = "Каяк", Price = 275M };
            var jacket = new Product { Name = "Жакет", Price = 48.95M };
            var kook = new Product { Name = "Кок", Price = 65.55M };
            var zenus = new Product { Name = "Зенус", Price = 21.1M };
            return new Product[] { kayak, jacket, kook, zenus };
        }
    }
}