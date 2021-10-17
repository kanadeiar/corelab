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
            var results = new List<string>();
            foreach (var p in Product.GetProducts())
            {
                var name = p?.Name ?? "<No Name>";
                var price = p?.Price ?? 0;
                var relatedName = p?.Related?.Name ?? "<None>";
                results.Add($"Имя: {name}, Цена: {price:C2}, Подчинен: {relatedName}");
            }
            return View(results);
        }
    }
}