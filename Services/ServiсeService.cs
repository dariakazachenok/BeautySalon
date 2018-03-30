using System.Collections.Generic;
using System.Linq;
using EntityFramework;
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

        public HairdresserService GetById(int id)
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
            databaseContex.SaveChanges();
          }

          public void Remove(int id)
          {
              var hairdresserService = databaseContex.HairdresserServices.FirstOrDefault(x => x.Id == id);
            databaseContex.HairdresserServices.Remove(hairdresserService);
            databaseContex.SaveChanges();
          }

        /*private readonly List<string> HairdresserServices = new List<string>
        {
            "Haircut for men", "Haircut for women", "Difficult coloring (ombre, balayage, shatush, bronzing)", "Lamination of hair", "Hair extension", "Hairstyle",
            "Coloring your hair with your paint"
        }; 

        public List<string> GetAllHairdresserServices()
        {
            return HairdresserServices.ToList();
        }

        private readonly List<string> Manicure = new List<string>
        {
            "Classic manicure", "Colorless coating", "Coating removal", "Hand care", "Pedicure", "Hand / Feet massage", "Nail extension" 
        };

        public List<string> GetAllManicure()
        {
            return Manicure.ToList();
        }

        private readonly List<string> CosmeticServices = new List<string>
        {
            "Eyelash extension", "Face cleaning", "Eyebrow correction", "Anti - aging spa care", "Treatment of hair loss", "Care for sensitive skin"
        };

        public List<string> GetAllCosmeticServices()
        {
            return CosmeticServices.ToList();
        } */
    }    
}



