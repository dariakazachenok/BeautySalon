using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;

namespace BeautySalon.Controllers
{
    public class ManicureController : Controller
    {
        private readonly ServiceService serviceService;

        public ManicureController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var services = serviceService.GetAllManicure();
            var manicureListViewModel = new ManicureListViewModel();

            services.ForEach(service =>
            {
                var serviceModel = new ManicureListItemViewModel();
                serviceModel.Id = service.Id;
                serviceModel.Nameservice = service.Nameservice;
                serviceModel.Price = service.Price;

                manicureListViewModel.Manicures.Add(serviceModel);
            });

            return View(manicureListViewModel);
        }

        // GET:  Manicure
        public ActionResult Create(int id = 0)
        {
            var manicuremodel = new ManicureModel();

            return View("Create", manicuremodel);
        }

        [HttpPost]

        public ActionResult Create(ManicureModel manicureModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", manicureModel);
            };

            Manicure manicure = new Manicure ();
            var manicureViewModel = new ManicureListViewModel();

            if (manicureModel.Id != null)
            {
                Console.WriteLine("Error");
            }

            manicure.Id = manicureModel.Id.HasValue ? manicureModel.Id.Value : 0;
            manicure.Nameservice = manicureModel.Nameservice;
            manicure.Price = manicureModel.Price;
            serviceService.Create(manicure);

            return RedirectToAction("Index");
        }

        // GET: Manicure
        public ActionResult Update(int id)
        {
            var manicureModel = new ManicureModel();

            var manicure = serviceService.GetByIdManicure(id);
            manicureModel.Id = manicure.Id;
            manicureModel.Nameservice = manicure.Nameservice;
            manicureModel.Price = manicure.Price;

            return View("Update", manicureModel);
        }

        [HttpPost]

        public ActionResult Update(ManicureModel manicureModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", manicureModel);
            };

            Manicure manicure = new Manicure();
            var manicureViewModel = new ManicureListViewModel();

            if (manicureModel.Id != null)
            {
                manicure = serviceService.GetByIdManicure(manicureModel.Id.Value);
                manicure.Nameservice = manicureModel.Nameservice;
                manicure.Price = manicureModel.Price;
                serviceService.Edit(manicure);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            serviceService.RemoveManicure(id);

            return RedirectToAction("Index");
        }
    }
}