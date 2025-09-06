using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders.PackageBuilders
{
    public class MountainPackageBuilder
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
        
        public MountainPackageBuilder SetId(int id)
        {
            _id = id;
            return this;
        }
        
        public MountainPackageBuilder SetName(string name)
        {
            _name = name ?? string.Empty;
            return this;
        }
        
        public MountainPackageBuilder SetPrice(decimal price)
        {
            _price = price;
            return this;
        }
        
        public MountainPackageBuilder SetDestination(string destination)
        {
            _destination = destination ?? string.Empty;
            return this;
        }
        
        public MountainPackageBuilder SetNumberOfDays(int days)
        {
            _numberOfDays = days;
            return this;
        }
        
        public MountainPackageBuilder SetCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        
        public MountainPackageBuilder SetAccommodationType(string accommodationType)
        {
            _accommodationType = accommodationType ?? string.Empty;
            return this;
        }
        
        public MountainPackageBuilder SetTransportationType(string transportationType)
        {
            _transportationType = transportationType ?? string.Empty;
            return this;
        }
        
        public MountainPackageBuilder AddActivity(string activity)
        {
            if (activity != null)
            {
                _activities.Add(activity);
            }
            return this;
        }
        
        public MountainPackageBuilder SetActivities(List<string> activities)
        {
            _activities = activities ?? new List<string>();
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
