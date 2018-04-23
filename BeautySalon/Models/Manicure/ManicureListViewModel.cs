using System.Collections.Generic;

namespace BeautySalon.Models
{
    public class ManicureListViewModel
    {
        public List<ManicureListItemViewModel> Manicures { get; set; }

        public ManicureListViewModel()
        {
            Manicures = new List<ManicureListItemViewModel>();
        }

    }
}
