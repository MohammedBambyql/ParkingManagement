using Microsoft.EntityFrameworkCore;
using ParkingManagement.Models;

namespace ParkingManagement.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 

        }

        public DbSet<Car> Cars { get; set; }
    }
}
