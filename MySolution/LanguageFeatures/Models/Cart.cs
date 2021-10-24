using System.Collections;
using System.Collections.Generic;

namespace LanguageFeatures.Model
{
    public class Cart : IProductSelection
    {
        private List<Product> _products = new List<Product>();
        //public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public Cart(params Product[] prods)
        {
            _products.AddRange(prods);
        }
        public IEnumerable<Product> Products { get => _products; }
    }
}