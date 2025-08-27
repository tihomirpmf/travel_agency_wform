using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    // Builder Pattern: Concrete builder for MountainPackage objects
    // Purpose: Encapsulates MountainPackage creation logic with fluent interface
    public class MountainPackageBuilder : IPackageBuilder
    {
        private int _id;
        private string _name = string.Empty;
        private decimal _price;
        private string _destination = string.Empty;
        private int _numberOfDays;
        private DateTime _createdAt = DateTime.Now;
        private string _accommodationType = string.Empty;
        private string _transportationType = string.Empty;
        private List<string> _activities = new List<string>();
        
        public IPackageBuilder SetId(int id)
        {
            _id = id;
            return this;
        }
        
        public IPackageBuilder SetName(string name)
        {
            _name = name;
            return this;
        }
        
        public IPackageBuilder SetPrice(decimal price)
        {
            _price = price;
            return this;
        }
        
        public IPackageBuilder SetDestination(string destination)
        {
            _destination = destination;
            return this;
        }
        
        public IPackageBuilder SetNumberOfDays(int days)
        {
            _numberOfDays = days;
            return this;
        }
        
        public IPackageBuilder SetCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        
        public MountainPackageBuilder SetAccommodationType(string accommodationType)
        {
            _accommodationType = accommodationType;
            return this;
        }
        
        public MountainPackageBuilder SetTransportationType(string transportationType)
        {
            _transportationType = transportationType;
            return this;
        }
        
        public MountainPackageBuilder AddActivity(string activity)
        {
            _activities.Add(activity);
            return this;
        }
        
        public MountainPackageBuilder SetActivities(List<string> activities)
        {
            _activities = activities;
            return this;
        }
        
        public TravelPackage Build()
        {
            return new MountainPackage
            {
                Id = _id,
                Name = _name,
                Price = _price,
                Destination = _destination,
                NumberOfDays = _numberOfDays,
                CreatedAt = _createdAt,
                Type = PackageType.Mountain,
                AccommodationType = _accommodationType,
                TransportationType = _transportationType,
                Activities = _activities
            };
        }
    }
}
