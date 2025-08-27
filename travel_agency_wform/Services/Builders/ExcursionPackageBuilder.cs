using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    // Builder Pattern: Concrete builder for ExcursionPackage objects
    // Purpose: Encapsulates ExcursionPackage creation logic with fluent interface and validation
    public class ExcursionPackageBuilder : IPackageBuilder
    {
        private int _id;
        private string _name = string.Empty;
        private decimal _price;
        private string _destination = string.Empty;
        private int _numberOfDays;
        private DateTime _createdAt = DateTime.Now;
        private string _transportationType = string.Empty;
        private string _guide = string.Empty;
        
        public IPackageBuilder SetId(int id)
        {
            _id = id;
            return this;
        }
        
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
        
        public IPackageBuilder SetCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        
        public ExcursionPackageBuilder SetTransportationType(string transportationType)
        {
            _transportationType = transportationType ?? throw new ArgumentNullException(nameof(transportationType));
            return this;
        }
        
        public ExcursionPackageBuilder SetGuide(string guide)
        {
            _guide = guide ?? throw new ArgumentNullException(nameof(guide));
            return this;
        }
        
        public TravelPackage Build()
        {
            if (string.IsNullOrWhiteSpace(_name))
                throw new InvalidOperationException("Package name is required.");
            
            if (string.IsNullOrWhiteSpace(_destination))
                throw new InvalidOperationException("Destination is required.");
            
            if (string.IsNullOrWhiteSpace(_transportationType))
                throw new InvalidOperationException("Transportation type is required.");
            
            if (string.IsNullOrWhiteSpace(_guide))
                throw new InvalidOperationException("Guide is required.");
            
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
