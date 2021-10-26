using System.Collections.Generic;

namespace Simple.Models
{
    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products =>
            new Product[] {
                new() { Name = "Каяк", Price = 275M },
                new() { Name = "Жакет", Price = 48.95M },
                new() { Name = "Кок", Price = 65.55M },
                new() { Name = "Зенус", Price = 21.1M },
            };
    }
}