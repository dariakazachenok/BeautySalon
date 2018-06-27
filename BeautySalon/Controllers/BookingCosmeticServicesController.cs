using System;
using BeautySalon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;

namespace BeautySalon.Controllers
{
    public class BookingCosmeticServicesController : Controller
    {
        private readonly CosmeticServiceService cosmeticServiceService;
        readonly ILogger logger;

        public BookingCosmeticServicesController(CosmeticServiceService cosmeticServiceService, ILogger<CosmeticServicesController> logger)
        {
            this.cosmeticServiceService = cosmeticServiceService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            var bookingServices = cosmeticServiceService.GetAllBookingCosmeticService();
            var bookingCosmeticServiceListViewModel = new BookingCosmeticServiceListViewModel();

            bookingServices.ForEach(bookingService =>
            {
                var bookingServiceModel = new BookingCosmeticServiceListItemViewModel();
                bookingServiceModel.Id = bookingService.Id;
                bookingServiceModel.Nameservice = bookingService.Nameservice;
                bookingServiceModel.Price = bookingService.Price;
                bookingServiceModel.VisitData = bookingService.VisitData;
                bookingServiceModel.MasterName = bookingService.MasterName;
                bookingServiceModel.FirstName = bookingService.FirstName;
                bookingServiceModel.LastName = bookingService.LastName;
                bookingServiceModel.Phone = bookingService.Phone;

                bookingCosmeticServiceListViewModel.BookingCosmeticServices.Add(bookingServiceModel);
            });

            return View(bookingCosmeticServiceListViewModel);
        }

        // GET: CosmeticService/Booking
        public ActionResult Create(int serviceId)
        {
            CosmeticService cosmeticService = cosmeticServiceService.GetByIdCosmeticService(serviceId);
            var bookingCosmeticServiceModel = new BookingCosmeticServiceModel()
            {
                ServiceId = cosmeticService.Id,
                Nameservice = cosmeticService.Nameservice,
                Price = cosmeticService.Price
            };

            return View("Create", bookingCosmeticServiceModel);
        }

        [HttpPost]
        public ActionResult Create(BookingCosmeticServiceModel bookingCosmeticServiceModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", bookingCosmeticServiceModel);
            };

            BookingCosmeticService bookingCosmeticService = new BookingCosmeticService();

            if (bookingCosmeticServiceModel.ServiceId != null)
            {
                Console.WriteLine("Error");
            }

            bookingCosmeticService.ServiceId = bookingCosmeticServiceModel.ServiceId.HasValue ? bookingCosmeticServiceModel.ServiceId.Value : 0;
            bookingCosmeticService.Nameservice = bookingCosmeticServiceModel.Nameservice;
            bookingCosmeticService.Price = bookingCosmeticServiceModel.Price;
            bookingCosmeticService.VisitData = bookingCosmeticServiceModel.VisitData;
            bookingCosmeticService.MasterName = bookingCosmeticServiceModel.MasterName;
            bookingCosmeticService.FirstName = bookingCosmeticServiceModel.FirstName;
            bookingCosmeticService.LastName = bookingCosmeticServiceModel.LastName;
            bookingCosmeticService.Phone = bookingCosmeticServiceModel.Phone;
            cosmeticServiceService.Create(bookingCosmeticService);

            return RedirectToAction("Index");
        }

        // GET: CosmeticService/Boooking
        public ActionResult Update(int Id)
        {
            var bookingCosmeticServiceModel = new BookingCosmeticServiceModel();

            var bookingCosmeticService = cosmeticServiceService.GetByIdBookingCosmeticService(Id);
            bookingCosmeticServiceModel.Nameservice = bookingCosmeticService.Nameservice;
            bookingCosmeticServiceModel.Price = bookingCosmeticService.Price;
            bookingCosmeticServiceModel.VisitData = bookingCosmeticService.VisitData;
            bookingCosmeticServiceModel.MasterName = bookingCosmeticService.MasterName;
            bookingCosmeticServiceModel.FirstName = bookingCosmeticService.FirstName;
            bookingCosmeticServiceModel.LastName = bookingCosmeticService.LastName;
            bookingCosmeticServiceModel.Phone = bookingCosmeticService.Phone;

            return View("Update", bookingCosmeticServiceModel);
        }

        // POST: CosmeticService/Boooking
        [HttpPost]
        public ActionResult Update(BookingCosmeticServiceModel bookingCosmeticServiceModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", bookingCosmeticServiceModel);
            };

            BookingCosmeticService bookingCosmeticService = new BookingCosmeticService();

            bookingCosmeticService.Id = bookingCosmeticServiceModel.Id.HasValue ? bookingCosmeticServiceModel.Id.Value : 0;
            bookingCosmeticService.Nameservice = bookingCosmeticServiceModel.Nameservice;
            bookingCosmeticService.Price = bookingCosmeticServiceModel.Price;
            bookingCosmeticService.VisitData = bookingCosmeticServiceModel.VisitData;
            bookingCosmeticService.MasterName = bookingCosmeticServiceModel.MasterName;
            bookingCosmeticService.FirstName = bookingCosmeticServiceModel.FirstName;
            bookingCosmeticService.LastName = bookingCosmeticServiceModel.LastName;
            bookingCosmeticService.Phone = bookingCosmeticServiceModel.Phone;
            cosmeticServiceService.Edit(bookingCosmeticService);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            cosmeticServiceService.RemoveBookingCosmeticService(id);

            return RedirectToAction("Index");
        }
    }
}