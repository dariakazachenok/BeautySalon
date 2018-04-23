using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;

namespace BeautySalon.Controllers
{
    public class HairdresserServicesController : Controller
    {
        private readonly ServiceService serviceService;

        public HairdresserServicesController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var services = serviceService.GetAllHairdresserService();
            var hairdresserServiceListViewModel = new HairdresserServiceListViewModel();

            services.ForEach(service =>
            {
                var serviceModel = new HairdresserServiceListItemViewModel();
                serviceModel.Id = service.Id;
                serviceModel.Nameservice = service.Nameservice;
                serviceModel.Price = service.Price;

                hairdresserServiceListViewModel.HairdresserServices.Add(serviceModel);
            });

            return View(hairdresserServiceListViewModel);
        }

        // GET: HairdresserService
        public ActionResult Create(int id = 0)
        {
            var hairdresserServicemodel = new HairdresserServiceModel();

            return View("Create", hairdresserServicemodel);
        }

        [HttpPost]

        public ActionResult Create(HairdresserServiceModel hairdresserServicemodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", hairdresserServicemodel);
            };

            HairdresserService hairdresserService = new HairdresserService();
            var hairdresserServiceViewModel = new HairdresserServiceListViewModel();

            if (hairdresserServicemodel.Id != null)
            {
                Console.WriteLine("Error");
            }

            hairdresserService.Id = hairdresserServicemodel.Id.HasValue ? hairdresserServicemodel.Id.Value : 0;
            hairdresserService.Nameservice = hairdresserServicemodel.Nameservice;
            hairdresserService.Price = hairdresserServicemodel.Price;
            serviceService.Create(hairdresserService);

            return RedirectToAction("Index");
        }

        // GET: HairdresserService
        public ActionResult Update(int id)
        {
            var hairdresserServicemodel = new HairdresserServiceModel();

            var hairdresserService = serviceService.GetByIdHairdresserService(id);
            hairdresserServicemodel.Id = hairdresserService.Id;
            hairdresserServicemodel.Nameservice = hairdresserService.Nameservice;
            hairdresserServicemodel.Price = hairdresserService.Price;

            return View("Update", hairdresserServicemodel);
        }

        [HttpPost]

        public ActionResult Update(HairdresserServiceModel hairdresserServicemodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", hairdresserServicemodel);
            };

            HairdresserService hairdresserService = new HairdresserService();
            var hairdresserServiceViewModel = new HairdresserServiceListViewModel();

            hairdresserService.Id = hairdresserServicemodel.Id.HasValue ? hairdresserServicemodel.Id.Value : 0;
            hairdresserService.Nameservice = hairdresserServicemodel.Nameservice;
            hairdresserService.Price = hairdresserServicemodel.Price;
            serviceService.Edit(hairdresserService);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            serviceService.RemoveHairdresserService(id);

            return RedirectToAction("Index");
        }
    }
}