﻿using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace BeautySalon.Controllers
{
    public class HairdresserServicesController : Controller
    {
        private readonly ServiceService serviceService;

        public HairdresserServicesController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
            /*var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer("Server=localdb-mssqllocaldb.database.windows.net;Database=beautysalondb;User Id=Dasha;Password=6700982Da");
            var databaseContext = new DatabaseContext(optionsBuilder.Options); */
        }

        // GET: HairdresserService
        public ActionResult Create(int id = 0)
        {
            var hairdresserServicemodel = new HairdresserServiceModel();

            if (id != 0)
            {
                var hairdresserService = serviceService.GetById(id);
                hairdresserServicemodel.Id = hairdresserService.Id;
                hairdresserServicemodel.Nameservice = hairdresserService.Nameservice;
                hairdresserServicemodel.Price = hairdresserService.Price;
                
            }
            return View("Create", hairdresserServicemodel);
        }

        [HttpPost]


        public ActionResult Update(HairdresserServiceModel hairdresserServicemodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", hairdresserServicemodel);
            };

            HairdresserService hairdresserService = new HairdresserService();

            if (hairdresserServicemodel.Id != null)
            {
                hairdresserService = serviceService.GetById(hairdresserServicemodel.Id.Value);
            }

            hairdresserService.Nameservice = hairdresserServicemodel.Nameservice;
            hairdresserService.Price = hairdresserServicemodel.Price;

            if (hairdresserServicemodel.Id != null)
            {
                serviceService.Edit(hairdresserService);
            }
            else
            {
                serviceService.Create(hairdresserService);
            }

            var hairdresserservices = serviceService.GetAllHairdresserService();
            var hairdresserServiceViewModel = new HairdresserServiceListViewModel();

            hairdresserservices.ForEach(sv =>
            {
                var serviceModel = new HairdresserServiceListItemViewModel();
                serviceModel.Nameservice = sv.Nameservice;
                serviceModel.Price= sv.Price;
                serviceModel.Id = sv.Id;


                hairdresserServiceViewModel.HairdresserService.Add(serviceModel);
            });
            return View("../Home/HairdresserService", hairdresserServiceViewModel);
        } 

        public ActionResult Delete(int id)
        {
            serviceService.Remove(id);
            var hairdresserservices = serviceService.GetAllHairdresserService();
            var hairdresserServiceListViewModel = new HairdresserServiceListViewModel();

            hairdresserservices.ForEach(sv =>
            {
                var serviceModel = new HairdresserServiceListItemViewModel();
                serviceModel.Nameservice = sv.Nameservice;
                serviceModel.Price = sv.Price;
                serviceModel.Id = sv.Id;

                hairdresserServiceListViewModel.HairdresserService.Add(serviceModel);
            });

            return View("../Home/HairdresserService", hairdresserServiceListViewModel);
        }
    }
}