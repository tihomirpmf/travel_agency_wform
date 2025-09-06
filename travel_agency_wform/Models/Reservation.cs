namespace travel_agency_wform.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PackageId { get; set; }
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
        Cancelled
    }
}
