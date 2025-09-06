using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Database.Adapters
{
    public interface IDatabaseAdapter
    {
        Task<bool> InitializeDatabaseAsync();
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task<int> AddClientAsync(Client client);
        Task<List<TravelPackage>> GetAllPackagesAsync();
        Task<TravelPackage?> GetPackageByIdAsync(int id);
        Task<int> AddPackageAsync(TravelPackage package);
        
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
