using System.Collections.Generic;

namespace BeautySalon.Models
{
    public class CosmeticServiceListViewModel
    {
        public List<CosmeticServiceListItemViewModel> CosmeticServices { get; set; }

        public CosmeticServiceListViewModel()
        {
            CosmeticServices = new List<CosmeticServiceListItemViewModel>();
        }
    }

}

