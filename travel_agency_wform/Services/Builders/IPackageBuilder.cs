using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    public interface IPackageBuilder
    {
        IPackageBuilder SetName(string name);
        IPackageBuilder SetPrice(decimal price);
        IPackageBuilder SetDestination(string destination);
        IPackageBuilder SetNumberOfDays(int days);
        TravelPackage Build();
    }
}
