namespace travel_agency_wform.Models
{
    public abstract class TravelPackage
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PackageType Type { get; set; }
        public string Destination { get; set; } = string.Empty;
        public int NumberOfDays { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        
        public abstract string GetPackageDetails();
        
        public override string ToString()
        {
            return $"{Name} - {Destination} - {Price}";
        }
    }
    
    public enum PackageType
    {
        Seaside,
        Mountain,
        Excursion,
        Cruise
    }
    
    public class SeasidePackage : TravelPackage
    {
        public string AccommodationType { get; set; } = string.Empty;
        public string TransportationType { get; set; } = string.Empty;
        
        public override string GetPackageDetails()
        {
            return $"Seaside Package: {Destination}, {AccommodationType} accommodation, {TransportationType} transport, {NumberOfDays} days";
        }

        public override string ToString()
        {
            return $"{Name} - {Destination} - {NumberOfDays} days - {Price:C}";
        }
    }
    
    public class MountainPackage : TravelPackage
    {
        public string AccommodationType { get; set; } = string.Empty;
        public string TransportationType { get; set; } = string.Empty;
        public List<string> Activities { get; set; } = new List<string>();
        
        public override string GetPackageDetails()
        {
            var activities = string.Join(", ", Activities);
            return $"Mountain Package: {Destination}, {AccommodationType} accommodation, {TransportationType} transport, Activities: {activities}, {NumberOfDays} days";
        }

        public override string ToString()
        {
            return $"{Name} - {Destination} - {NumberOfDays} days - {Price:C}";
        }
    }
    
    public class ExcursionPackage : TravelPackage
    {
        public string TransportationType { get; set; } = string.Empty;
        public string Guide { get; set; } = string.Empty;
        
        public override string GetPackageDetails()
        {
            return $"Excursion Package: {Destination}, {TransportationType} transport, Guide: {Guide}, {NumberOfDays} days";
        }

        public override string ToString()
        {
            return $"{Name} - {Destination} - {NumberOfDays} days - {Price:C}";
        }
    }
    
    public class CruisePackage : TravelPackage
    {
        public string Ship { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
        public string CabinType { get; set; } = string.Empty;
        
        public override string GetPackageDetails()
        {
            return $"Cruise Package: {Ship}, Route: {Route}, Departure: {DepartureDate:dd/MM/yyyy}, Cabin: {CabinType}, {NumberOfDays} days";
        }

        public override string ToString()
        {
            return $"{Name} - {Route} - {NumberOfDays} days - {Price:C}";
        }
    }
}
