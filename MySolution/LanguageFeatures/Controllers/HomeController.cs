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
            // var results = new List<string>();
            // foreach (var p in Product.GetProducts())
            // {
            //     var name = p?.Name ?? "<No Name>";
            //     var price = p?.Price ?? 0;
            //     var relatedName = p?.Related?.Name ?? "<None>";
            //     results.Add($"Имя: {name}, Цена: {price:C2}, Подчинен: {relatedName}");
            // }
            var data = new object[] { 210M, 29.5M, "apple", "orange", 100, 10 };
            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case decimal d:
                        total += d;
                        break;
                    case int iVv when iVv > 50:
                        total += iVv;
                        break;
                }
            }
            return View(new string[] { $"Итог: {total:C2}" });
        }
    }
}