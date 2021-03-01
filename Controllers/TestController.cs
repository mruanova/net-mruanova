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
    public class TestController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public TestController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.username = "mruanova";
            Task<List<Item>> t = GetProjects();
            t.Wait();
            List<Item> items = t.Result;
            return View(items);
        }

        private readonly HttpClient _httpClient = new HttpClient();
        [HttpGet, Route("projects")]
        public async Task<List<Item>> GetProjects()
        {
            string URL = "https://246gg84zg8.execute-api.us-west-2.amazonaws.com/prod/projects";
            string contents = await _httpClient.GetStringAsync(URL);
            _httpClient.Dispose();
            byte[] byteArray = Encoding.UTF8.GetBytes(contents);//ASCII
            MemoryStream stream = new MemoryStream(byteArray);
            ValueTask<testMvcNoHttps.Models.Response> task = JsonSerializer.DeserializeAsync<Response>(stream);
            Response response = task.Result;
            var result = response.body.Items.OrderBy(o => o.ProjectId).ToList();//LINQ
            return result;
        }
    }
}
