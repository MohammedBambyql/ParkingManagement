using ParkingManagement.Models;

public class Vehicle
{
    public int VehicleId { get; set; }
    public string LicensePlateNumber { get; set; }
    public string Type { get; set; } // e.g., Car, Bike, Truck
    public string OwnerInfo { get; set; }
    public ParkingTicket ParkingTicket { get; set; }
}
