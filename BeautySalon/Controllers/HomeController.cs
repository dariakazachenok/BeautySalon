using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeautySalon.Models;
using Services;

namespace BeautySalon.Controllers
{
    public class HomeController : Controller
    {
            private readonly ServiсeService serviсeService;

            public IActionResult CatalogHairdressersServices()
            {
                var services = serviсeService.GetAllCatalogHairdresserServices(); /*contact to the collection in the service*/
                var servicesViewModel = new ServicesViewModel(); 
                List<string> ServicesViewModel = services;
                return View(servicesViewModel);

            }

            public IActionResult Index()
            {
             return View();
            }

            public IActionResult About()
            {
             ViewData["Message"] = "Your application description page.";

             return View();
            }

            public IActionResult Contact()
            {
             ViewData["Message"] = "Your contact page.";

             return View();
            }

            public IActionResult Error()
            {
             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
    }
}  
