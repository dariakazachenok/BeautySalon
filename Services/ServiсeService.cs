using System.Collections.Generic;
using System.Linq;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class ServiceService
    {
        private readonly DatabaseContext databaseContex;

        public ServiceService(DatabaseContext databaseContex)
        {
            this.databaseContex = databaseContex;
        }

        public List<HairdresserService> GetAllHairdresserService()
        {
            return databaseContex.HairdresserServices.ToList();
        }

        public List<CosmeticService> GetAllCosmeticService()
        {
            return databaseContex.CosmeticServices.ToList();
        }

        public List<Manicure> GetAllManicure()
        {
            return databaseContex.Manicures.ToList();
        }

        public HairdresserService GetByIdHairdresserService(int id)
        {
            return databaseContex.HairdresserServices.FirstOrDefault(x => x.Id == id);
        }

        public void Create(HairdresserService hairdresserService)
        {
            databaseContex.HairdresserServices.Add(hairdresserService);
            databaseContex.SaveChanges();
        }

        public void Edit(HairdresserService hairdresserService)
        {   
            //1
            databaseContex.Entry(hairdresserService).State = EntityState.Modified;

            //2
           // databaseContex.Update(hairdresserService);
            databaseContex.SaveChanges();
        }

        public void RemoveHairdresserService(int id)
        {
            var hairdresserService = databaseContex.HairdresserServices.FirstOrDefault(x => x.Id == id);
            databaseContex.HairdresserServices.Remove(hairdresserService);
            databaseContex.SaveChanges();
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

        public Manicure GetByIdManicure(int id)
        {
            return databaseContex.Manicures.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Manicure manicure)
        {
            databaseContex.Manicures.Add(manicure);
            databaseContex.SaveChanges();
        }

        public void Edit(Manicure manicure)
        {   
            databaseContex.SaveChanges();
        }

        public void RemoveManicure(int id)
        {
            var manicure = databaseContex.Manicures.FirstOrDefault(x => x.Id == id);
            databaseContex.Manicures.Remove(manicure);
            databaseContex.SaveChanges();
        }
    }    
}



