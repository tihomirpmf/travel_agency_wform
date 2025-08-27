namespace travel_agency_wform.Models
{
    // Entity Pattern: Reservation entity with navigation properties
    // Purpose: Represents reservation data with relationships to Client and TravelPackage
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PackageId { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public int NumberOfTravelers { get; set; } = 1;
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Active;
        
        public virtual Client Client { get; set; } = null!;
        public virtual TravelPackage Package { get; set; } = null!;
        
        public override string ToString()
        {
            return $"{Package?.Name ?? "Unknown"} - {NumberOfTravelers} travelers - ${TotalPrice} - {Status}";
        }
    }
    
    public enum ReservationStatus
    {
        Active,
        Cancelled,
        Completed
    }
}
