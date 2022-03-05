using Contracts;
using Contracts.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestSvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RequestSvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestClient<ProductInfoRequest> _client;

        public HomeController(ILogger<HomeController> logger, IRequestClient<ProductInfoRequest> client)
        {
            _logger = logger;
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PrivacyAsync()
        {
            Product p = null;
            // request from the remote service
            using (var request = _client.Create(new ProductInfoRequest { Slug = "test", Delay = 1000 }))
            {
                var response = await request.GetResponse<ProductInfoResponse>();
                p = response.Message.Product;
            }
            ViewBag.Product = p;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
