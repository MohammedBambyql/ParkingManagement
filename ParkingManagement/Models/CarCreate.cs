using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Models
{
    public class CarCreate
    {
        [Required, MaxLength(100)]
        public string SlotNumber { get; set; } = "";
        [Required, MaxLength(100)]
        public string VehicleNumber { get; set; } = "";
        [Required, MaxLength(100)]
        public string OwnerName { get; set; } = "";
        [Required, MaxLength(100)]
        public string ContactNumber { get; set; } = "";
        [Required]
        public DateTime TimeOut { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
