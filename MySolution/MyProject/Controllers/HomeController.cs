using System;
using Microsoft.AspNetCore.Mvc;

namespace MyProhect.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }


}