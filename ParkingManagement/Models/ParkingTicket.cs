namespace ParkingManagement.Models;

public class ParkingTicket
{
    public int TicketId { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public int ParkingSpotId { get; set; }
    public int VehicleId { get; set; }
    public bool IsPaid { get; set; }
    public ParkingSpot ParkingSpot { get; set; }
    public Vehicle Vehicle { get; set; }
    public Payment Payment { get; set; }
}