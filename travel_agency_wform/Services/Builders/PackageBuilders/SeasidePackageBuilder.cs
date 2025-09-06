using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders.PackageBuilders
{
    public class SeasidePackageBuilder
    {
        private int _id;
        private string _name = string.Empty;
        private decimal _price;
        private string _destination = string.Empty;
        private int _numberOfDays;
        private DateTime _createdAt = DateTime.Now;
        private string _accommodationType = string.Empty;
        private string _transportationType = string.Empty;
        
        public SeasidePackageBuilder SetId(int id)
        {
            _id = id;
            return this;
        }
        
        public SeasidePackageBuilder SetName(string name)
        {
            _name = name ?? string.Empty;
            return this;
        }
        
        public SeasidePackageBuilder SetPrice(decimal price)
        {
            _price = price;
            return this;
        }
        
        public SeasidePackageBuilder SetDestination(string destination)
        {
            _destination = destination ?? string.Empty;
            return this;
        }
        
        public SeasidePackageBuilder SetNumberOfDays(int days)
        {
            _numberOfDays = days;
            return this;
        }
        
        public SeasidePackageBuilder SetCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        
        public SeasidePackageBuilder SetAccommodationType(string accommodationType)
        {
            _accommodationType = accommodationType ?? string.Empty;
            return this;
        }
        
        public SeasidePackageBuilder SetTransportationType(string transportationType)
        {
            _transportationType = transportationType ?? string.Empty;
            return this;
        }
        
        public TravelPackage Build()
        {
            return new SeasidePackage
            {
                Id = _id,
                Name = _name,
                Price = _price,
                Destination = _destination,
                NumberOfDays = _numberOfDays,
                CreatedAt = _createdAt,
                Type = PackageType.Seaside,
                AccommodationType = _accommodationType,
                TransportationType = _transportationType
            };
        }
    }
}
