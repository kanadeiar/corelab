using System;
using System.Collections.Generic;

namespace LanguageFeatures.Model
{
    public static class MyExtentionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (var p in products)
            {
                total += p?.Price ?? 0;
            }
            return total;
        }
        public static IEnumerable<Product> FilterBy(this IEnumerable<Product> products, Func<Product, bool> selector)
        {
            foreach (var p in products)
            {
                if (selector(p))
                    yield return p;
            }
        }
    }
}
