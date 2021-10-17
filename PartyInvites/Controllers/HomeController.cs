using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Model;
using PartyInvites.Data;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResponseForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResponseForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ListResponses()
        {
            var responses = Repository.Responses.Where(r => r.WillAttend == true);
            return View(responses);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
