namespace LanguageFeatures.Model
{
    public class Product
    {
        public string? Name { get; set; }
        public string Category { get; set; } = "Спорт";
        public decimal? Price { get; set; }
        public Product? Related { get; set; }
        public static Product[] GetProducts()
        {
            var kayak = new Product { Name = "Каяк", Category = "Водный спорт", Price = 275M };
            var jacket = new Product { Name = "Жакет", Price = 48.95M };
            kayak.Related = jacket;
            return new Product[] { kayak, jacket, new Product() };
        }
    }
}