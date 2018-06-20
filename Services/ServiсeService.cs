using System.Collections.Generic;
using System.Linq;
using Identity;
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
            //1
            databaseContex.Entry(manicure).State = EntityState.Modified;

            //2
            // databaseContex.Update(manicure);
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



