using Microsoft.AspNetCore.Mvc;
using MyCollectionSite.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.IO;

namespace MyCollectionSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HatRepository repository;

        public HomeController(
            ILogger<HomeController> logger,
            HatRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()

        {
            //1st run, before repository created
            // using var jsonFile = System.IO.File.OpenRead("Data/collection.json");
            //var items = JsonSerializer.Deserialize<CollectionItem[]>(jsonFile);

            var items = repository.Get();
            return View(items);
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