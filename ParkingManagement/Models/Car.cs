using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Models
{
    public class Car
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string SlotNumber { get; set; } = "";
        [MaxLength(100)]
        public string VehicleNumber { get; set; } = "";
        [MaxLength(100)]
        public string OwnerName { get; set; } = "";
        [MaxLength(100)]
        public string ContactNumber { get; set; } = "";
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        [Precision(16,2)]
        public decimal Cost { get; set; }
    }
}
