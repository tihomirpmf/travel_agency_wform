using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders;
using travel_agency_wform.Services.Observers;
using travel_agency_wform.Services.Builders.PackageBuilders;
using travel_agency_wform.Services.Database.Adapters;
using travel_agency_wform.Services.Database.Factories;

namespace travel_agency_wform.Services
{
    public class TravelAgencyFacade : ITravelAgencyFacade
    {
        private readonly IDatabaseAdapter _databaseAdapter;
        private readonly ConfigurationManager _configManager;
        
        public TravelAgencyFacade()
        {
            _configManager = ConfigurationManager.Instance;
            var connectionString = _configManager.ConnectionString;
            
            _databaseAdapter = DatabaseFactory.CreateAdapter(connectionString);
        }
        
        public async Task<bool> InitializeAsync()
        {
            return await _databaseAdapter.InitializeDatabaseAsync();
        }
        
        public SeasidePackageBuilder CreateSeasidePackage()
        {
            return new SeasidePackageBuilder();
        }
        
        public MountainPackageBuilder CreateMountainPackage()
        {
            return new MountainPackageBuilder();
        }
        
        public ExcursionPackageBuilder CreateExcursionPackage()
        {
            return new ExcursionPackageBuilder();
        }
        
        public CruisePackageBuilder CreateCruisePackage()
        {
            return new CruisePackageBuilder();
        }
        
        public ClientBuilder CreateClient()
        {
            return new ClientBuilder();
        }
        
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _databaseAdapter.GetAllClientsAsync();
        }
        
        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _databaseAdapter.GetClientByIdAsync(id);
        }
        

        
        public async Task<int> AddClientAsync(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.FirstName) || string.IsNullOrWhiteSpace(client.LastName))
                throw new ArgumentException("First name and last name are required.");
            
            if (string.IsNullOrWhiteSpace(client.PassportNumber))
                throw new ArgumentException("Passport number is required.");
            
            if (string.IsNullOrWhiteSpace(client.Email))
                throw new ArgumentException("Email is required.");
            

            
            var clientId = await _databaseAdapter.AddClientAsync(client);
            
            DataChangeNotifier.Instance.NotifyClientAdded(clientId);
            
            return clientId;
        }
        

        
        // Package Management
        public async Task<List<TravelPackage>> GetAllPackagesAsync()
        {
            return await _databaseAdapter.GetAllPackagesAsync();
        }
        

        
        public async Task<TravelPackage?> GetPackageByIdAsync(int id)
        {
            return await _databaseAdapter.GetPackageByIdAsync(id);
        }
        
        public async Task<int> AddPackageAsync(TravelPackage package)
        {
            if (string.IsNullOrWhiteSpace(package.Name))
                throw new ArgumentException("Package name is required.");
            
            if (package.Price <= 0)
                throw new ArgumentException("Package price must be greater than zero.");
            
            if (package.Type != PackageType.Cruise && string.IsNullOrWhiteSpace(package.Destination))
                throw new ArgumentException("Destination is required.");
            
            if (package.NumberOfDays <= 0)
                throw new ArgumentException("Number of days must be greater than zero.");
            
            var packageId = await _databaseAdapter.AddPackageAsync(package);
            
            DataChangeNotifier.Instance.NotifyPackageAdded(packageId);
            
            return packageId;
        }
        

        
        // Reservation Management
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _databaseAdapter.GetAllReservationsAsync();
        }
        
        public async Task<List<Reservation>> GetReservationsByClientIdAsync(int clientId)
        {
            return await _databaseAdapter.GetReservationsByClientIdAsync(clientId);
        }
        
        public async Task<int> ReservePackageAsync(int clientId, int packageId, int numberOfTravelers)
        {
            // Validate client and package exist
            var client = await _databaseAdapter.GetClientByIdAsync(clientId);
            if (client == null)
                throw new ArgumentException("Client not found.");
            
            var package = await _databaseAdapter.GetPackageByIdAsync(packageId);
            if (package == null)
                throw new ArgumentException("Package not found.");
            
            if (numberOfTravelers <= 0)
                throw new ArgumentException("Number of travelers must be greater than zero.");
            
            // Calculate total price
            var totalPrice = package.Price * numberOfTravelers;
            
            var reservation = new Reservation
            {
                ClientId = clientId,
                PackageId = packageId,
                NumberOfTravelers = numberOfTravelers,
                TotalPrice = totalPrice,
                Status = ReservationStatus.Active
            };
            
            var reservationId = await _databaseAdapter.AddReservationAsync(reservation);
            
            // Notify observers about the change
            DataChangeNotifier.Instance.NotifyReservationAdded(reservationId);
            
            return reservationId;
        }
        
        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            var reservation = await _databaseAdapter.GetReservationByIdAsync(reservationId);
            if (reservation == null)
                throw new ArgumentException("Reservation not found.");
            
            if (reservation.Status != ReservationStatus.Active)
                throw new InvalidOperationException("Only active reservations can be cancelled.");
            
            var success = await _databaseAdapter.CancelReservationAsync(reservationId);
            
            // Notify observers about the change
            if (success)
            {
                DataChangeNotifier.Instance.NotifyReservationCancelled(reservationId);
            }
            
            return success;
        }
        
        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            var reservation = await _databaseAdapter.GetReservationByIdAsync(reservationId);
            if (reservation == null)
                throw new ArgumentException("Reservation not found.");
            
            if (reservation.Status != ReservationStatus.Cancelled)
                throw new InvalidOperationException("Only cancelled reservations can be deleted.");
            
            var success = await _databaseAdapter.DeleteReservationAsync(reservationId);
            if (success)
            {
                DataChangeNotifier.Instance.NotifyReservationCancelled(reservationId);
            }
            return success;
        }
        
        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            if (reservation.Id <= 0)
                throw new ArgumentException("Invalid reservation ID.");
            
            // Trust caller-provided TotalPrice to allow manual overrides in the UI
            
            var success = await _databaseAdapter.UpdateReservationAsync(reservation);
            
            // Notify observers about the change
            if (success)
            {
                DataChangeNotifier.Instance.NotifyReservationUpdated(reservation.Id);
            }
            
            return success;
        }
        
        public async Task<Reservation?> GetReservationByIdAsync(int reservationId)
        {
            try
            {
                return await _databaseAdapter.GetReservationByIdAsync(reservationId);
            }
            catch
            {
                return null;
            }
        }
        
        // Utility Methods
        public async Task<List<string>> GetAllDestinationsAsync()
        {
            return await _databaseAdapter.GetAllDestinationsAsync();
        }
        
        public async Task<bool> CreateBackupAsync()
        {
            return await _databaseAdapter.CreateBackupAsync();
        }
        
        public string GetAgencyName()
        {
            return _configManager.AgencyName;
        }
        
        public IDatabaseAdapter GetDatabaseAdapter()
        {
            return _databaseAdapter;
        }
    }
}
