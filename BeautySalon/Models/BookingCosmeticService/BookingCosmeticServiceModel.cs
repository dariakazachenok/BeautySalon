using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BookingCosmeticServiceModel
    {
        public int? ServiceId { get; set; }
        public string Nameservice { get; set; }
        public int Price { get; set; }

        [Display(Name = "Visit date")]
        [Required(ErrorMessage = "Please enter visit data")]
        public DateTime VisitData { get; set; }

        [Display(Name = "Name of the master")]
        [Required(ErrorMessage = "Select enter name of the master")]
        public int MasterName { get; set; }

        [Required(ErrorMessage = "Please enter firstName")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter lastName")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter phone")]
        public int? Phone { get; set; }
    }
}
