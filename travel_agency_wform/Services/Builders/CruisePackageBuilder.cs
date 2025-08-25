using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    public class CruisePackageBuilder : IPackageBuilder
    {
        private string _name = string.Empty;
        private decimal _price;
        private string _destination = string.Empty;
        private int _numberOfDays;
        private string _ship = string.Empty;
        private string _route = string.Empty;
        private DateTime _departureDate;
        private string _cabinType = string.Empty;
        private string _transportationType = string.Empty;
        
        public IPackageBuilder SetName(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            return this;
        }
        
        public IPackageBuilder SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            _price = price;
            return this;
        }
        
        public IPackageBuilder SetDestination(string destination)
        {
            _destination = destination ?? throw new ArgumentNullException(nameof(destination));
            return this;
        }
        
        public IPackageBuilder SetNumberOfDays(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Number of days must be greater than zero.");
            _numberOfDays = days;
            return this;
        }
        
        public CruisePackageBuilder SetShip(string ship)
        {
            _ship = ship ?? throw new ArgumentNullException(nameof(ship));
            return this;
        }
        
        public CruisePackageBuilder SetRoute(string route)
        {
            _route = route ?? throw new ArgumentNullException(nameof(route));
            return this;
        }
        
        public CruisePackageBuilder SetDepartureDate(DateTime departureDate)
        {
            if (departureDate <= DateTime.Now)
                throw new ArgumentException("Departure date must be in the future.");
            _departureDate = departureDate;
            return this;
        }
        
        public CruisePackageBuilder SetCabinType(string cabinType)
        {
            _cabinType = cabinType ?? throw new ArgumentNullException(nameof(cabinType));
            return this;
        }
        
        public CruisePackageBuilder SetTransportationType(string transportationType)
        {
            _transportationType = transportationType ?? throw new ArgumentNullException(nameof(transportationType));
            return this;
        }
        
        public TravelPackage Build()
        {
            if (string.IsNullOrWhiteSpace(_name))
                throw new InvalidOperationException("Package name is required.");
            
            if (string.IsNullOrWhiteSpace(_destination))
                throw new InvalidOperationException("Destination is required.");
            
            if (string.IsNullOrWhiteSpace(_ship))
                throw new InvalidOperationException("Ship is required.");
            
            if (string.IsNullOrWhiteSpace(_route))
                throw new InvalidOperationException("Route is required.");
            
            if (string.IsNullOrWhiteSpace(_cabinType))
                throw new InvalidOperationException("Cabin type is required.");
            
            if (_departureDate == default)
                throw new InvalidOperationException("Departure date is required.");
            
            return new CruisePackage
            {
                Name = _name,
                Price = _price,
                Type = PackageType.Cruise,
                Destination = _destination,
                NumberOfDays = _numberOfDays,
                Ship = _ship,
                Route = _route,
                DepartureDate = _departureDate,
                CabinType = _cabinType,
                TransportationType = _transportationType
            };
        }
    }
}
