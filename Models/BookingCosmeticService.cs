using System;

namespace Models
{
    public class BookingCosmeticService
    {
        public int? Id { get; set; }
        public int? ServiceId { get; set; }
        public string Nameservice { get; set; }
        public int Price { get; set; }
        public DateTime VisitData { get; set; }
        public int MasterName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Phone { get; set; }
    }
}
