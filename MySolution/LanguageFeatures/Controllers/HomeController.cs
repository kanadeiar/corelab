using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Model;
using System.Collections;
using System.Collections.Generic;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new Product[]
            {
                new Product { Name = "Каяк", Price = 200M },
                new Product { Name = "Жакет", Price = 23.5M },
                new Product { Name = "Фрак", Price = 19.5M },
                new Product { Name = "Флаг", Price = 34.95M },
            };

            var arrayTotal = products
                .FilterBy(p => (p?.Price ?? 0) >= 20)
                .TotalPrices();
            var nameTotal = products
                .FilterBy(p => p?.Name?[0] == 'Ф')
                .TotalPrices();

            return View(new string[] { $"Итог фильтра цены: {arrayTotal:C2}", $"Итог фильтра имени: {nameTotal:C2}" });
        }
    }
}