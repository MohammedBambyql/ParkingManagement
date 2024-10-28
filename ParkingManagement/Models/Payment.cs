using System;

namespace ParkingManagement.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } // e.g., Cash, Card, Digital
    public bool IsCompleted { get; set; }
    public int ParkingTicketId { get; set; }
    public ParkingTicket ParkingTicket { get; set; }
}