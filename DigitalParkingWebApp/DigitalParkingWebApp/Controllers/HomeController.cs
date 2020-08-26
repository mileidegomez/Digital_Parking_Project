using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigitalParkingWebApp.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using DigitalParkingWebApp.Helpers;

namespace DigitalParkingWebApp.Controllers
{
    public class HomeController : Controller
    {

        string StorageName = "storageaccountparking";
        string StorageKey = "tU15S7M4BOAMqbCeL4aNkyeLNuJ8Da0hisSeg4UbAT0xRuNpXaYInbMpFAg01jwtJ4p73mFDSXU1HQuei5Jw5Q==";
        string TableName = "tableLugares()";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {

            string jsonData;
            AzureTables.GetAllEntity(StorageName, StorageKey, TableName, out jsonData);
            MaterialUsage materialUsage = JsonConvert.DeserializeObject<MaterialUsage>(jsonData);

            return View(materialUsage);
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

        public IActionResult Historico()
        {

            string jsonData;
            AzureTables.GetAllEntity(StorageName, StorageKey, TableName, out jsonData);
            MaterialUsage materialUsage = JsonConvert.DeserializeObject<MaterialUsage>(jsonData);

            return View(materialUsage);
        }
    }
}
