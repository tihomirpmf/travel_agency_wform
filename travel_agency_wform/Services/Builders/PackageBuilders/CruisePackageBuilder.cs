using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders.PackageBuilders
{
    public class CruisePackageBuilder
    {
        private int _id;
        private string _name = string.Empty;
        private decimal _price;
        private int _numberOfDays;
        private DateTime _createdAt = DateTime.Now;
        private string _ship = string.Empty;
        private string _route = string.Empty;
        private DateTime _departureDate;
        private string _cabinType = string.Empty;
        
        public CruisePackageBuilder SetId(int id)
        {
            _id = id;
            return this;
        }
        
        public CruisePackageBuilder SetName(string name)
        {
            _name = name ?? string.Empty;
            return this;
        }
        
        public CruisePackageBuilder SetPrice(decimal price)
        {
            _price = price;
            return this;
        }
        
        public CruisePackageBuilder SetNumberOfDays(int days)
        {
            _numberOfDays = days;
            return this;
        }
        
        public CruisePackageBuilder SetCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        
        public CruisePackageBuilder SetShip(string ship)
        {
            _ship = ship ?? string.Empty;
            return this;
        }
        
        public CruisePackageBuilder SetRoute(string route)
        {
            _route = route ?? string.Empty;
            return this;
        }
        
        public CruisePackageBuilder SetDepartureDate(DateTime departureDate)
        {
            _departureDate = departureDate;
            return this;
        }
        
        public CruisePackageBuilder SetCabinType(string cabinType)
        {
            _cabinType = cabinType ?? string.Empty;
            return this;
        }
        
        public TravelPackage Build()
        {
            return new CruisePackage
            {
                Id = _id,
                Name = _name,
                Price = _price,
                Type = PackageType.Cruise,
                NumberOfDays = _numberOfDays,
                CreatedAt = _createdAt,
                Ship = _ship,
                Route = _route,
                DepartureDate = _departureDate,
                CabinType = _cabinType
            };
        }
    }
}
