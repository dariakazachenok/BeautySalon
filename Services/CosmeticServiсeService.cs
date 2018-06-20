using System.Collections.Generic;
using System.Linq;
using Identity;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class CosmeticServiceService
    {
        private readonly DatabaseContext databaseContex;

        public CosmeticServiceService(DatabaseContext databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public List<CosmeticService> GetAllCosmeticService()
        {
            return databaseContex.CosmeticServices.ToList();
        }

        public CosmeticService GetByIdCosmeticService(int id)
        {
            return databaseContex.CosmeticServices.FirstOrDefault(x => x.Id == id);
        }

        public void Create(CosmeticService cosmeticService)
        {
              databaseContex.CosmeticServices.Add(cosmeticService);
              databaseContex.SaveChanges();
        }

        public void Edit(CosmeticService cosmeticService)
        {
            //1
            databaseContex.Entry(cosmeticService).State = EntityState.Modified;

            //2
            // databaseContex.Update(cosmeticService);
            databaseContex.SaveChanges();
        }

        public void RemoveCosmeticService(int id)
        {
             var cosmeticService = databaseContex.CosmeticServices.FirstOrDefault(x => x.Id == id);
             databaseContex.CosmeticServices.Remove(cosmeticService);
             databaseContex.SaveChanges();
        }

        public void Create(BookingCosmeticService bookingCosmeticService)
        {
            databaseContex.BookingCosmeticServices.Add(bookingCosmeticService);
            databaseContex.SaveChanges();
        }

        public List<BookingCosmeticService> GetAllBookingCosmeticService()
        {
            return databaseContex.BookingCosmeticServices.ToList();
        }

        public void Edit(BookingCosmeticService bookingCosmeticService)
        {
            //1
            databaseContex.Entry(bookingCosmeticService).State = EntityState.Modified;

            //2
            // databaseContex.Update(cosmeticService);
            databaseContex.SaveChanges();
        }

        public BookingCosmeticService GetByIdBookingCosmeticService(int id)
        {
            return databaseContex.BookingCosmeticServices.FirstOrDefault(x => x.Id == id);
        }
    }
}
