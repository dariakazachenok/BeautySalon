using System.Collections.Generic;

namespace BeautySalon.Models
{
    public class HairdresserServiceListViewModel
    {

       public List<HairdresserServiceListItemViewModel> HairdresserServices { get; set; }

        public HairdresserServiceListViewModel()
        {
            HairdresserServices = new List<HairdresserServiceListItemViewModel>();
        }
    }
}