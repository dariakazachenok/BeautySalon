using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServiсeService
    {
        
        private readonly List<string> HairdresserServices = new List<string>
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
        }
    }     
}



