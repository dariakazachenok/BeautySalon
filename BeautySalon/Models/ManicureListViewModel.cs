using System.Collections.Generic;

namespace BeautySalon.Models
{
    public class ManicureListViewModel
    {
        public List<ManicureListItemViewModel> Manicure { get; set; }

        public ManicureListViewModel()
        {
            Manicure = new List<ManicureListItemViewModel>();
        }

    }
}
