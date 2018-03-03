using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServiсeService
    {
        
        private readonly List<string> HairdresserServices = new List<string>
        {
            "Haircut for men", "Haircut for women", "Difficult coloring (ombre, balayage, shatush, bronzing)", "Lamination of hair"
        };

        public List<string> GetAllHairdresserServices()
        {
            return HairdresserServices.ToList();
        }

        private readonly List<string> Manicure = new List<string>
        {
            "Classic manicure", "Colorless coating", "Coating removal", "Hand care"
        };

        public List<string> GetAllManicure()
        {
            return Manicure.ToList();
        }

        private readonly List<string> CosmeticServices = new List<string>
        {
            "Eyelash extension", "Face cleaning", "Eyebrow correction", "Anti - aging spa care"
        };

        public List<string> GetAllCosmeticServices()
        {
            return CosmeticServices.ToList();
        }
    }     
}



