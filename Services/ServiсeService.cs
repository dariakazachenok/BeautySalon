using System;
using EntityFramework;
using Models;


namespace Services
{
    public class ServiсeService
    {
        private readonly DatabaseContext databaseContext;

       /* public ServiсeService()
        {
            databaseContext = new DatabaseContext();
        }

        public void CreateService(HairdresserServices hairdresserService)
        {
            databaseContext.HairdresserServices.Add(hairdresserService);
            databaseContext.SaveChanges();
        } */

        

        /* public void EditService(Service service)
         {
             databaseContext.SaveChanges();
         }

         public void RemoveService(int id)
         {
             var service = databaseContext.Services.FirstOrDefault(x => x.Id == id);
             databaseContext.Services.Remove(service);
             databaseContext.SaveChanges();
         }

         public List<Service> GetAll()
         {
             return databaseContext.Services.ToList();
         }

         public Service GetById(int id)
         {
             return databaseContext.Services.FirstOrDefault(x => x.Id == id);
         } */

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



