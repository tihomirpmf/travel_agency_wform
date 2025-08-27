using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Database
{
    public interface IDatabaseAdapter
    {
        Task<bool> InitializeDatabaseAsync();
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task<Client?> GetClientByPassportAsync(string passportNumber);
        Task<int> AddClientAsync(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
        
        Task<List<TravelPackage>> GetAllPackagesAsync();
        Task<TravelPackage?> GetPackageByIdAsync(int id);
        Task<List<TravelPackage>> GetPackagesByTypeAsync(PackageType type);
        Task<int> AddPackageAsync(TravelPackage package);
        Task<bool> UpdatePackageAsync(TravelPackage package);
        Task<bool> DeletePackageAsync(int id);
        
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<List<Reservation>> GetReservationsByClientIdAsync(int clientId);
        Task<Reservation?> GetReservationByIdAsync(int id);
        Task<int> AddReservationAsync(Reservation reservation);
        Task<bool> UpdateReservationAsync(Reservation reservation);
        Task<bool> CancelReservationAsync(int id);
        Task<bool> DeleteReservationAsync(int id);
        
        Task<List<string>> GetAllDestinationsAsync();
        Task<bool> CreateBackupAsync();
    }
}
