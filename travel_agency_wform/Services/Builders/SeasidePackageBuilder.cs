using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    // Builder Pattern: Concrete builder for SeasidePackage objects
    // Purpose: Encapsulates SeasidePackage creation logic with fluent interface
    public class SeasidePackageBuilder : IPackageBuilder
    {
        private string _name = string.Empty;
        private decimal _price;
        private string _destination = string.Empty;
        private int _numberOfDays;
        private string _accommodationType = string.Empty;
        private string _transportationType = string.Empty;
        
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
        
        public SeasidePackageBuilder SetAccommodationType(string accommodationType)
        {
            _accommodationType = accommodationType;
            return this;
        }
        
        public SeasidePackageBuilder SetTransportationType(string transportationType)
        {
            _transportationType = transportationType;
            return this;
        }
        
        public TravelPackage Build()
        {
            return new SeasidePackage
            {
                Name = _name,
                Price = _price,
                Destination = _destination,
                NumberOfDays = _numberOfDays,
                Type = PackageType.Seaside,
                AccommodationType = _accommodationType,
                TransportationType = _transportationType
            };
        }
    }
}
