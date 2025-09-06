using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders;
using travel_agency_wform.Services.Builders.PackageBuilders;
using travel_agency_wform.Services.Database.Adapters;

namespace travel_agency_wform.Services
{
    public interface ITravelAgencyFacade
    {
        Task<bool> InitializeAsync();
        
        // Package Builder Methods
        SeasidePackageBuilder CreateSeasidePackage();
        MountainPackageBuilder CreateMountainPackage();
        ExcursionPackageBuilder CreateExcursionPackage();
        CruisePackageBuilder CreateCruisePackage();
        ClientBuilder CreateClient();
        
        // Client Management
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task<int> AddClientAsync(Client client);
        
        // Package Management
        Task<List<TravelPackage>> GetAllPackagesAsync();
        Task<TravelPackage?> GetPackageByIdAsync(int id);
        Task<int> AddPackageAsync(TravelPackage package);
        
        // Reservation Management
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<List<Reservation>> GetReservationsByClientIdAsync(int clientId);
        Task<int> ReservePackageAsync(int clientId, int packageId, int numberOfTravelers);
        Task<bool> CancelReservationAsync(int reservationId);
        Task<bool> DeleteReservationAsync(int reservationId);
        Task<bool> UpdateReservationAsync(Reservation reservation);
        Task<Reservation?> GetReservationByIdAsync(int reservationId);
        
        // Utility Methods
        Task<List<string>> GetAllDestinationsAsync();
        Task<bool> CreateBackupAsync();
        string GetAgencyName();
        IDatabaseAdapter GetDatabaseAdapter();
    }
}
