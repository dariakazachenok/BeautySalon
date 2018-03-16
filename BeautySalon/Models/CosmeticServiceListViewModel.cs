using System.Collections.Generic;

namespace BeautySalon.Models
{
    public class CosmeticServiceListViewModel
    {
        public List<CosmeticServiceListItemViewModel> CosmeticService { get; set; }

        public CosmeticServiceListViewModel()
        {
            CosmeticService = new List<CosmeticServiceListItemViewModel>();
        }
    }

}

