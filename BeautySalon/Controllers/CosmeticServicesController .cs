using BeautySalon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;

namespace BeautySalon.Controllers
{
    public class CosmeticServicesController : Controller
    {
        private readonly ServiceService serviceService;

        public CosmeticServicesController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var services = serviceService.GetAllCosmeticService();
            var cosmeticServiceListViewModel = new CosmeticServiceListViewModel();

            services.ForEach(service =>
            {
                var serviceModel = new CosmeticServiceListItemViewModel();
                serviceModel.Id = service.Id;
                serviceModel.Nameservice = service.Nameservice;
                serviceModel.Price = service.Price;

                cosmeticServiceListViewModel.CosmeticServices.Add(serviceModel);
            });

            return View(cosmeticServiceListViewModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: CosmeticService
        public ActionResult Create(int id = 0)
        {
            var cosmeticServicemodel = new CosmeticServiceModel();

            return View("Create", cosmeticServicemodel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CosmeticServiceModel cosmeticServicemodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", cosmeticServicemodel);
            };

            CosmeticService cosmeticService = new CosmeticService();
            var cosmeticServiceViewModel = new CosmeticServiceListViewModel();

            if (cosmeticServicemodel.Id != null)
            {
                Console.WriteLine("Error");
            }

            cosmeticService.Id = cosmeticServicemodel.Id.HasValue ? cosmeticServicemodel.Id.Value : 0;
            cosmeticService.Nameservice = cosmeticServicemodel.Nameservice;
            cosmeticService.Price = cosmeticServicemodel.Price;
            serviceService.Create(cosmeticService);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        // GET: CosmeticService
        public ActionResult Update(int id)
        {
            var cosmeticServicemodel = new CosmeticServiceModel();

            var cosmeticService = serviceService.GetByIdCosmeticService(id);
            cosmeticServicemodel.Id = cosmeticService.Id;
            cosmeticServicemodel.Nameservice = cosmeticService.Nameservice;
            cosmeticServicemodel.Price = cosmeticService.Price;

            return View("Update", cosmeticServicemodel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(CosmeticServiceModel cosmeticServicemodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", cosmeticServicemodel);
            };

            CosmeticService cosmeticService = new CosmeticService();
            var cosmeticServiceViewModel = new CosmeticServiceListViewModel();

            cosmeticService.Id = cosmeticServicemodel.Id.HasValue ? cosmeticServicemodel.Id.Value : 0;
            cosmeticService.Nameservice = cosmeticServicemodel.Nameservice;
            cosmeticService.Price = cosmeticServicemodel.Price;
            serviceService.Edit(cosmeticService);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            serviceService.RemoveCosmeticService(id);

            return RedirectToAction("Index");
        }
    }
}