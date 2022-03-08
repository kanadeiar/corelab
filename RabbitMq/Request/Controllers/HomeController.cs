using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Request.Models;
using System.Diagnostics;
using Test.Core.Contracts;
using Test.Core.Models;

namespace Request.Controllers
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

        public async Task<IActionResult> Myrequest()
        {
            Product model = null;

            using (var request = _client.Create(new ProductInfoRequest { Slug = "test" }))
            {
                var response = await request.GetResponse<ProductInfoResponse>();
                model = response.Message.Product;
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}