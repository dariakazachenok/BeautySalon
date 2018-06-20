using System.Collections.Generic;

namespace BeautySalon.Models
{
    public class BookingCosmeticServiceListViewModel
    {
        public List<BookingCosmeticServiceListItemViewModel> BookingCosmeticServices { get; set; }

        public BookingCosmeticServiceListViewModel()
        {
            BookingCosmeticServices = new List<BookingCosmeticServiceListItemViewModel>();
        }
    }

}

