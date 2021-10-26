using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Models;

namespace Simple.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource dataSource = new ProductDataSource();
        public IActionResult Index()
        {
            var result = dataSource.Products;
            return View(result);
        }
    }
}