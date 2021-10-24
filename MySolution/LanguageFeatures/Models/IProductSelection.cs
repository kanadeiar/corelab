using System.Collections.Generic;
using System.Linq;

namespace LanguageFeatures.Model
{
    public interface IProductSelection
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<string> Names => Products.Select(p => p.Name ?? "<null>");
    }
}