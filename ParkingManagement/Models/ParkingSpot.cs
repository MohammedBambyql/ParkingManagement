namespace ParkingManagement.Models;

public class ParkingSpot
{
    public int SpotId { get; set; }
    public string Type { get; set; } // e.g., Regular, Handicapped, Electric
    public bool IsOccupied { get; set; }
    public ParkingTicket ParkingTicket { get; set; }
}