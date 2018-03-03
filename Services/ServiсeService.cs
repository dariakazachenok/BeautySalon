using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServiсeService
    {
        
        private readonly List<string> CatalogHairdresserServices = new List<string>
        {
            "Haircut for men", "Haircut for women", "Difficult coloring (ombre, balayage, shatush, bronzing)", "Lamination of hair"
        };

        public List<string> GetAllCatalogHairdresserServices()
        {
            return CatalogHairdresserServices.ToList();
        }

        private readonly List<string> CatalogManicure = new List<string>
        {
            "Classic manicure", "Colorless coating", "Coating removal", "Hand care"
        };

        public List<string> GetAllCatalogManicure()
        {
            return CatalogManicure.ToList();
        }

        private readonly List<string> CatalogCosmeticServices = new List<string>
        {
            "Eyelash extension", "Face cleaning", "Eyebrow correction", "Anti - aging spa care"
        };

        public List<string> GetAllCatalogCosmeticServices()
        {
            return CatalogCosmeticServices.ToList();
        }

    }     
}



