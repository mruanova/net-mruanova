using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text.Json;
using testMvcNoHttps.Models;

namespace testMvcNoHttps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static readonly HttpClient client = new HttpClient();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async Task<List<Item>> HttpGetResponse()
        {
            string url = "https://246gg84zg8.execute-api.us-west-2.amazonaws.com/prod/projects";
            var streamTask = client.GetStreamAsync(url);
            Response repositories = await JsonSerializer.DeserializeAsync<Response>(await streamTask);
            return repositories.body.Items.OrderBy(o=>o.ProjectId).ToList();//LINQ
        }
    }
}
