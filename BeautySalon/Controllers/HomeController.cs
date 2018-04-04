using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeautySalon.Models;
using Services;

namespace BeautySalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceService serviceService;

        public HomeController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
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
