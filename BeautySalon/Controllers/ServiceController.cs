using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace BeautySalon.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiсeService serviceService;

        public ServiceController()
        {
            serviceService = new ServiсeService();
        }
        // GET: HairdresserService
        public ActionResult CreateHairdresserService(int id = 0)
        {
            var hairdresserServicemodel = new HairdresserServiceModel();

            if (id != 0)
            {
                var hairdresserService = serviceService.GetById(id);
                hairdresserServicemodel.Id = hairdresserService.Id;
                hairdresserServicemodel.Nameservice = hairdresserService.Nameservice;
                hairdresserServicemodel.Price = hairdresserService.Price;
                
            }
            return View("EditHairdresserService", hairdresserServicemodel);
        }

        [HttpPost]
        public ActionResult UpdateHairdresserService(HairdresserServiceModel hairdresserServicemodel)
        {
            if (!ModelState.IsValid)
            {
                return View("EditHairdresserService", hairdresserServicemodel);
            };

            HairdresserService hairdresserService = new HairdresserService();

            if (hairdresserServicemodel.Id != null)
            {
                hairdresserService = serviceService.GetById(hairdresserServicemodel.Id.Value);
            }

            hairdresserService.Nameservice = hairdresserServicemodel.Nameservice;
            hairdresserService.Price = hairdresserServicemodel.Price;

            if (hairdresserService.Id != null)
            {
                serviceService.EditHairdresserService(hairdresserService);
            }
            else
            {
                serviceService.CreateHairdresserService(hairdresserService);
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
            return View("EditHairdresserService", hairdresserServiceViewModel);
        }
    }
}