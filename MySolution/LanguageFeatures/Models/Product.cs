namespace LanguageFeatures.Model
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public static Product[] GetProducts()
        {
            var kayak = new Product { Name = "Каяк", Price = 275M };
            var jacket = new Product { Name = "Жакет", Price = 48.95M };
            return new Product[] { kayak, jacket, null };
        }
    }
}