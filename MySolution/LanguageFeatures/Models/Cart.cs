using System.Collections;
using System.Collections.Generic;

namespace LanguageFeatures.Model
{
    public class Cart : IEnumerable<Product>
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}