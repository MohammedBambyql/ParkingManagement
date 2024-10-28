using Microsoft.EntityFrameworkCore;
using ParkingManagement.Models;

namespace ParkingManagement.Data;

public class ParkingContext : DbContext
{
    public ParkingContext(DbContextOptions options ):base(options)
    {
            
    }
    public DbSet<ParkingSpot> ParkingSpots { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<ParkingTicket> ParkingTickets { get; set; }
    public DbSet<Payment> Payments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure ParkingSpot entity
        modelBuilder.Entity<ParkingSpot>(entity =>
        {
            entity.HasKey(ps => ps.SpotId);
            entity.Property(ps => ps.Type)
                  .IsRequired()
                  .HasMaxLength(50);
            entity.Property(ps => ps.IsOccupied)
                  .IsRequired();

            // One-to-One relationship between ParkingSpot and ParkingTicket
            entity.HasOne(ps => ps.ParkingTicket)
                  .WithOne(pt => pt.ParkingSpot)
                  .HasForeignKey<ParkingTicket>(pt => pt.ParkingSpotId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Vehicle entity
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(v => v.VehicleId);
            entity.Property(v => v.LicensePlateNumber)
                  .IsRequired()
                  .HasMaxLength(20);
            entity.Property(v => v.Type)
                  .HasMaxLength(20);
            entity.Property(v => v.OwnerInfo)
                  .HasMaxLength(100);

            // One-to-One relationship between Vehicle and ParkingTicket
            entity.HasOne(v => v.ParkingTicket)
                  .WithOne(pt => pt.Vehicle)
                  .HasForeignKey<ParkingTicket>(pt => pt.VehicleId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure ParkingTicket entity
        modelBuilder.Entity<ParkingTicket>(entity =>
        {
            entity.HasKey(pt => pt.TicketId);
            entity.Property(pt => pt.EntryTime)
                  .IsRequired();
            entity.Property(pt => pt.IsPaid)
                  .IsRequired();

            // Define the one-to-one relationship with Payment
            entity.HasOne(pt => pt.Payment)
                  .WithOne(p => p.ParkingTicket)
                  .HasForeignKey<Payment>(p => p.ParkingTicketId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Payment entity
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(p => p.PaymentId);
            entity.Property(p => p.Amount)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");
            entity.Property(p => p.PaymentMethod)
                  .IsRequired()
                  .HasMaxLength(50);
            entity.Property(p => p.IsCompleted)
                  .IsRequired();
        });
    }
}