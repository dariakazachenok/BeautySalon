using System.Collections.Generic;

namespace BeautySalon.Models
{
    public class HairdresserServiceListViewModel
    {

       public List<HairdresserServiceListItemViewModel> HairdresserService { get; set; }

        public HairdresserServiceListViewModel()
        {
            HairdresserService = new List<HairdresserServiceListItemViewModel>();
        }

       
    }
}