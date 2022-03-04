﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error(string id)
        {
            return id switch
            {
                "404" => View("Error404"),
                _ => Content($"Status --- {id}"),
            };
        }
    }
}
