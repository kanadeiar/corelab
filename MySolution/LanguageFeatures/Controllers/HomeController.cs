using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IProductSelection cart = new Cart
            (
                new Product { Name = "Каяк", Price = 200M },
                new Product { Name = "Жакет", Price = 23.5M },
                new Product { Name = "Фрак", Price = 19.5M },
                new Product { Name = "Флаг", Price = 34.95M }
            );
            return View(cart.Names);
        }
    }
}