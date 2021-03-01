using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testMvcNoHttps.Models;
using System.Text.Json;
using System.Text;

namespace testMvcNoHttps.Controllers
{
    public class BasicController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BasicController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.username = "mruanova";
            return View();
        }
    }
}
