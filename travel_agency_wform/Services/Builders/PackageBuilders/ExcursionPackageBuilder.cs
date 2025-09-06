using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders.PackageBuilders
{
    public class ExcursionPackageBuilder
    {
        private int _id;
        private string _name = string.Empty;
        private decimal _price;
        private string _destination = string.Empty;
        private int _numberOfDays;
        private DateTime _createdAt = DateTime.Now;
        private string _transportationType = string.Empty;
        private string _guide = string.Empty;
        
        public ExcursionPackageBuilder SetId(int id)
        {
            _id = id;
            return this;
        }
        
        public ExcursionPackageBuilder SetName(string name)
        {
            _name = name ?? string.Empty;
            return this;
        }
        
        public ExcursionPackageBuilder SetPrice(decimal price)
        {
            _price = price;
            return this;
        }
        
        public ExcursionPackageBuilder SetDestination(string destination)
        {
            _destination = destination ?? string.Empty;
            return this;
        }
        
        public ExcursionPackageBuilder SetNumberOfDays(int days)
        {
            _numberOfDays = days;
            return this;
        }
        
        public ExcursionPackageBuilder SetCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        
        public ExcursionPackageBuilder SetTransportationType(string transportationType)
        {
            _transportationType = transportationType ?? string.Empty;
            return this;
        }
        
        public ExcursionPackageBuilder SetGuide(string guide)
        {
            _guide = guide ?? string.Empty;
            return this;
        }
        
        public TravelPackage Build()
        {
            return new ExcursionPackage
            {
                Id = _id,
                Name = _name,
                Price = _price,
                Type = PackageType.Excursion,
                Destination = _destination,
                NumberOfDays = _numberOfDays,
                CreatedAt = _createdAt,
                TransportationType = _transportationType,
                Guide = _guide
            };
        }
    }
}
