using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders;
using travel_agency_wform.Services.Database;

namespace travel_agency_wform.Services
{
    // Service Layer Pattern: Main business logic interface
    // Purpose: Provides high-level operations combining multiple patterns (Builder, Strategy, etc.)
    public interface ITravelAgencyService
    {
        // Initialization
        Task<bool> InitializeAsync();
        
        // Package Builder Methods
        SeasidePackageBuilder CreateSeasidePackage();
        MountainPackageBuilder CreateMountainPackage();
        ExcursionPackageBuilder CreateExcursionPackage();
        CruisePackageBuilder CreateCruisePackage();
        
        // Client Management
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task<Client?> GetClientByPassportAsync(string passportNumber);
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
