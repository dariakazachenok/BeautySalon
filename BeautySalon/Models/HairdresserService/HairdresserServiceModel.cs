using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class HairdresserServiceModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter NameService")]
        [StringLength(100)]
        public string Nameservice { get; set; }

        [Required(ErrorMessage = "Please enter Price")]
        public int Price { get; set; }
    }
}
