using DockerEc2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace DockerEc2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<WeatherForecast> forecasts = new List<WeatherForecast>();
            var client = HttpClientAccessor.HttpClient;

            var response = await client.GetStringAsync("https://localhost:7281/WeatherForecast");
            forecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(response)?? new List<WeatherForecast>();
             


            return View(forecasts);
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