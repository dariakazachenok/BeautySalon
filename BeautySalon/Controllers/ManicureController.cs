using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace BeautySalon.Controllers
{
    public class ManicureController : Controller
    {
        private readonly ServiceService serviceService;

        public ManicureController(ServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        public IActionResult Manicure()
        {
            var services = serviceService.GetAllManicure();
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

        // GET: HairdresserService
        public ActionResult Create(int id = 0)
        {
            var manicuremodel = new ManicureModel();

            if (id != 0)
            {
                var manicure = serviceService.GetByIdManicure(id);
                manicuremodel.Id = manicure.Id;
                manicuremodel.Nameservice = manicure.Nameservice;
                manicuremodel.Price = manicure.Price;
                
            }
            return View("Create", manicuremodel);
        }

        [HttpPost]


        public ActionResult Update(ManicureModel manicuremodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", manicuremodel);
            };

            Manicure manicure = new Manicure();

            if (manicuremodel.Id != null)
            {
                manicure = serviceService.GetByIdManicure(manicuremodel.Id.Value);
            }

            manicure.Nameservice = manicuremodel.Nameservice;
            manicure.Price = manicuremodel.Price;

            if (manicuremodel.Id != null)
            {
                serviceService.Edit(manicure);
            }
            else
            {
                serviceService.Create(manicure);
            }

            var manicures = serviceService.GetAllManicure();
            var manicureViewModel = new ManicureListViewModel();

            manicures.ForEach(sv =>
            {
                var serviceModel = new ManicureListItemViewModel();
                serviceModel.Nameservice = sv.Nameservice;
                serviceModel.Price= sv.Price;
                serviceModel.Id = sv.Id;


                manicureViewModel.Manicure.Add(serviceModel);
            });
            return View("Manicure", manicureViewModel);
        } 

        public ActionResult Delete(int id)
        {
            serviceService.RemoveManicure(id);
            var manicures = serviceService.GetAllManicure();
            var manicureListViewModel = new ManicureListViewModel();

            manicures.ForEach(m =>
            {
                var serviceModel = new ManicureListItemViewModel();
                serviceModel.Nameservice = m.Nameservice;
                serviceModel.Price = m.Price;
                serviceModel.Id = m.Id;

                manicureListViewModel.Manicure.Add(serviceModel);
            });

            return View("Manicure", manicureListViewModel);
        }
    }
}