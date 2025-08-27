using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    // Builder Pattern: Interface for constructing TravelPackage objects step by step
    // Purpose: Provides fluent API for complex object creation with different package types
    public interface IPackageBuilder
    {
        IPackageBuilder SetId(int id);
        IPackageBuilder SetName(string name);
        IPackageBuilder SetPrice(decimal price);
        IPackageBuilder SetDestination(string destination);
        IPackageBuilder SetNumberOfDays(int days);
        IPackageBuilder SetCreatedAt(DateTime createdAt);
        TravelPackage Build();
    }
}
