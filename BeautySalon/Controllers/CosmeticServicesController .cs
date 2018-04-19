using BeautySalon.Models;
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

                cosmeticServiceListViewModel.CosmeticService.Add(serviceModel);
            });

            return View(cosmeticServiceListViewModel);
        }

        // GET: CosmeticService
        public ActionResult Create(int id = 0)
        {
            var cosmeticServicemodel = new CosmeticServiceModel();

            if (id != 0)
            {
                var cosmeticService = serviceService.GetByIdCosmeticService(id);
                cosmeticServicemodel.Id = cosmeticService.Id;
                cosmeticServicemodel.Nameservice = cosmeticService.Nameservice;
                cosmeticServicemodel.Price = cosmeticService.Price;
                
            }
            return View("Create", cosmeticServicemodel);
        }

        [HttpPost]

        public ActionResult Update(CosmeticServiceModel cosmeticServicemodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", cosmeticServicemodel);
            };

            CosmeticService cosmeticService = new CosmeticService();
            var cosmeticServiceViewModel = new CosmeticServiceListViewModel();

            if (cosmeticServicemodel.Id != null)
            {
                //cosmeticService = serviceService.GetByIdCosmeticService(cosmeticServicemodel.Id.Value);
                cosmeticService.Id = cosmeticServicemodel.Id.HasValue ? cosmeticServicemodel.Id.Value : 0;
                cosmeticService.Nameservice = cosmeticServicemodel.Nameservice;
                cosmeticService.Price = cosmeticServicemodel.Price;
                serviceService.Edit(cosmeticService);

                var cosmeticservices = serviceService.GetAllCosmeticService();
                cosmeticservices.ForEach(cos =>
                {
                    var serviceModel = new CosmeticServiceListItemViewModel();
                    serviceModel.Nameservice = cos.Nameservice;
                    serviceModel.Price = cos.Price;
                    serviceModel.Id = cos.Id;

                    cosmeticServiceViewModel.CosmeticService.Add(serviceModel);
                });
            }
            Console.WriteLine("Error");
            return View("Index", cosmeticServiceViewModel);
        }

        public ActionResult Delete(int id)
        {
            serviceService.RemoveCosmeticService(id);
            var cosmeticservices = serviceService.GetAllCosmeticService();
            var cosmeticServiceListViewModel = new CosmeticServiceListViewModel();

            cosmeticservices.ForEach(sv =>
            {
                var serviceModel = new CosmeticServiceListItemViewModel();
                serviceModel.Nameservice = sv.Nameservice;
                serviceModel.Price = sv.Price;
                serviceModel.Id = sv.Id;

                cosmeticServiceListViewModel.CosmeticService.Add(serviceModel);
            });

            return View("Index", cosmeticServiceListViewModel);
        }
    }
}