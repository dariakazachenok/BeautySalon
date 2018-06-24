using System;

namespace BeautySalon.Models
{
    public class BookingCosmeticServiceListItemViewModel
    {
        public int? Id { get; set; }
        public string Nameservice { get; set; }
        public int Price { get; set; }
        public DateTime VisitData { get; set; }
        public int MasterName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Phone { get; set; }
    }
}
