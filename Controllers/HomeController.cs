using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testMvcNoHttps.Models;

namespace testMvcNoHttps.Controllers
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
            Task<List<Item>> t = testMvcNoHttps.Program.HttpGetResponse();
            t.Wait();
            List<Item> items = t.Result;
            ViewBag.username = "mruanova";
            return View(items);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
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
