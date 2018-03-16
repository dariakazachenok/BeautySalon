
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeautySalon.Models;
using EntityFramework;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace BeautySalon.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ServiсeService serviсeService;

        public HomeController()
        {
            serviсeService = new ServiсeService();
        }

        public IActionResult HairdresserService()
         {
             var services = serviсeService.GetAllHairdresserService(); 
             var hairdresserServiceListViewModel = new HairdresserServiceListViewModel();

             services.ForEach(service =>
             {
                 var serviceModel = new HairdresserServiceListItemViewModel();
                 serviceModel.Id = service.Id;
                 serviceModel.Nameservice = service.Nameservice;
                 serviceModel.Price = service.Price;

                 hairdresserServiceListViewModel.HairdresserService.Add(serviceModel);
             });

             return View(hairdresserServiceListViewModel);
         }

        public IActionResult CosmeticService()
        {
            var services = serviсeService.GetAllCosmeticService(); 
             var cosmeticServiceListViewModel = new CosmeticServiceListViewModel();

             services.ForEach(service =>
             {
                 var serviceModel = new CosmeticServiceListItemViewModel();
                 serviceModel.Id = service.Id;
                 serviceModel.Nameservice = service.Nameservice;
                 serviceModel.Price = service.Price;

                 cosmeticServiceListViewModel.CosmeticService.Add(serviceModel);
             });

             return View(cosmeticServiceListViewModel);
        }

        public IActionResult Manicure()
        {
            var services = serviсeService.GetAllManicure();
            var manicureListViewModel = new ManicureListViewModel();

            services.ForEach(service =>
            {
                var serviceModel = new ManicureListItemViewModel();
                serviceModel.Id = service.Id;
                serviceModel.Nameservice = service.Nameservice;
                serviceModel.Price = service.Price;

                manicureListViewModel.Manicure.Add(serviceModel);
            });

            return View(manicureListViewModel);
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
