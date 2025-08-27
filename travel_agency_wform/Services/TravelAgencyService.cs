using travel_agency_wform.Models;
using travel_agency_wform.Services.Database;
using travel_agency_wform.Services.Builders;
using travel_agency_wform.Services.Observers;

namespace travel_agency_wform.Services
{
    public class TravelAgencyService
    {
        private readonly IDatabaseAdapter _databaseAdapter;
        private readonly ConfigurationManager _configManager;
        
        public TravelAgencyService()
        {
            _configManager = ConfigurationManager.Instance;
            var connectionString = _configManager.ConnectionString;
            
            // Abstract Factory: choose provider and get matching adapter
            var provider = DatabaseFactory.CreateProvider();
            _ = provider.CreateConnection(connectionString); // ensure provider is valid; connection can be used as needed
            _databaseAdapter = provider.CreateAdapter(connectionString);
        }
        
        public async Task<bool> InitializeAsync()
        {
            var success = await _databaseAdapter.InitializeDatabaseAsync();
            if (success)
            {
                // Add some sample data if the database is empty
                await AddSampleDataIfEmptyAsync();
            }
            return success;
        }
        
        private async Task AddSampleDataIfEmptyAsync()
        {
            try
            {
                var clients = await GetAllClientsAsync();
                if (!clients.Any())
                {
                    // Add sample client
                    var sampleClient = new Client
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        PassportNumber = "AB123456",
                        DateOfBirth = new DateTime(1985, 5, 15),
                        Email = "john.doe@email.com",
                        PhoneNumber = "+1-555-0123"
                    };
                    await AddClientAsync(sampleClient);
                }
                
                var packages = await GetAllPackagesAsync();
                if (!packages.Any())
                {
                    // Add sample packages
                    var seasidePackage = new SeasidePackage
                    {
                        Name = "Tropical Paradise",
                        Price = 1299.99m,
                        Type = PackageType.Seaside,
                        Destination = "Maldives",
                        NumberOfDays = 7,
                        AccommodationType = "Beach Resort",
                        TransportationType = "Flight + Transfer"
                    };
                    await AddPackageAsync(seasidePackage);
                    
                    var mountainPackage = new MountainPackage
                    {
                        Name = "Alpine Adventure",
                        Price = 899.99m,
                        Type = PackageType.Mountain,
                        Destination = "Swiss Alps",
                        NumberOfDays = 5,
                        AccommodationType = "Mountain Lodge",
                        TransportationType = "Train + Cable Car",
                        Activities = new List<string> { "Hiking", "Skiing", "Mountain Biking" }
                    };
                    await AddPackageAsync(mountainPackage);
                    
                    var excursionPackage = new ExcursionPackage
                    {
                        Name = "Historical Rome Tour",
                        Price = 599.99m,
                        Type = PackageType.Excursion,
                        Destination = "Rome, Italy",
                        NumberOfDays = 3,
                        TransportationType = "Bus + Walking",
                        Guide = "Expert Local Guide"
                    };
                    await AddPackageAsync(excursionPackage);
                    
                    var cruisePackage = new CruisePackage
                    {
                        Name = "Caribbean Dream Cruise",
                        Price = 1899.99m,
                        Type = PackageType.Cruise,
                        Destination = "Caribbean Islands",
                        NumberOfDays = 10,
                        Ship = "Royal Caribbean - Harmony of the Seas",
                        Route = "Miami - Bahamas - Jamaica - Mexico - Miami",
                        DepartureDate = DateTime.Now.AddMonths(3),
                        CabinType = "Ocean View Balcony",
                        TransportationType = "Flight to Miami + Cruise Ship"
                    };
                    await AddPackageAsync(cruisePackage);
                }
                
                // Note: AddClientAsync and AddPackageAsync will automatically notify observers
            }
            catch
            {
                // Ignore errors when adding sample data
            }
        }
        
        // Client Management
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _databaseAdapter.GetAllClientsAsync();
        }
        
        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _databaseAdapter.GetClientByIdAsync(id);
        }
        
        public async Task<Client?> GetClientByPassportAsync(string passportNumber)
        {
            return await _databaseAdapter.GetClientByPassportAsync(passportNumber);
        }
        
        public async Task<int> AddClientAsync(Client client)
        {
            // Validate client data
            if (string.IsNullOrWhiteSpace(client.FirstName) || string.IsNullOrWhiteSpace(client.LastName))
                throw new ArgumentException("First name and last name are required.");
            
            if (string.IsNullOrWhiteSpace(client.PassportNumber))
                throw new ArgumentException("Passport number is required.");
            
            if (string.IsNullOrWhiteSpace(client.Email))
                throw new ArgumentException("Email is required.");
            
            // Check if passport number already exists
            var existingClient = await _databaseAdapter.GetClientByPassportAsync(client.PassportNumber);
            if (existingClient != null)
                throw new InvalidOperationException("A client with this passport number already exists.");
            
            var clientId = await _databaseAdapter.AddClientAsync(client);
            
            // Notify observers about the change
            DataChangeNotifier.Instance.NotifyClientAdded(clientId);
            
            return clientId;
        }
        
        public async Task<bool> UpdateClientAsync(Client client)
        {
            if (client.Id <= 0)
                throw new ArgumentException("Invalid client ID.");
            
            var success = await _databaseAdapter.UpdateClientAsync(client);
            
            // Notify observers about the change
            if (success)
            {
                DataChangeNotifier.Instance.NotifyClientUpdated(client.Id);
            }
            
            return success;
        }
        
        public async Task<bool> DeleteClientAsync(int id)
        {
            // Check if client has active reservations
            var reservations = await _databaseAdapter.GetReservationsByClientIdAsync(id);
            var activeReservations = reservations.Where(r => r.Status == ReservationStatus.Active).ToList();
            
            if (activeReservations.Any())
                throw new InvalidOperationException("Cannot delete client with active reservations.");
            
            var success = await _databaseAdapter.DeleteClientAsync(id);
            
            // Notify observers about the change
            if (success)
            {
                DataChangeNotifier.Instance.NotifyClientDeleted(id);
            }
            
            return success;
        }
        
        // Package Management
        public async Task<List<TravelPackage>> GetAllPackagesAsync()
        {
            return await _databaseAdapter.GetAllPackagesAsync();
        }
        
        public async Task<List<TravelPackage>> GetPackagesByTypeAsync(PackageType type)
        {
            return await _databaseAdapter.GetPackagesByTypeAsync(type);
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
            
            if (string.IsNullOrWhiteSpace(package.Destination))
                throw new ArgumentException("Destination is required.");
            
            if (package.NumberOfDays <= 0)
                throw new ArgumentException("Number of days must be greater than zero.");
            
            var packageId = await _databaseAdapter.AddPackageAsync(package);
            
            // Notify observers about the change
            DataChangeNotifier.Instance.NotifyPackageAdded(packageId);
            
            return packageId;
        }
        
        public async Task<bool> UpdatePackageAsync(TravelPackage package)
        {
            if (package.Id <= 0)
                throw new ArgumentException("Invalid package ID.");
            
            var success = await _databaseAdapter.UpdatePackageAsync(package);
            
            // Notify observers about the change
            if (success)
            {
                DataChangeNotifier.Instance.NotifyPackageUpdated(package.Id);
            }
            
            return success;
        }
        
        public async Task<bool> DeletePackageAsync(int id)
        {
            // Check if package has active reservations
            var reservations = await _databaseAdapter.GetAllReservationsAsync();
            var activeReservations = reservations.Where(r => r.PackageId == id && r.Status == ReservationStatus.Active).ToList();
            
            if (activeReservations.Any())
                throw new InvalidOperationException("Cannot delete package with active reservations.");
            
            var success = await _databaseAdapter.DeletePackageAsync(id);
            
            // Notify observers about the change
            if (success)
            {
                DataChangeNotifier.Instance.NotifyPackageDeleted(id);
            }
            
            return success;
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
        
        // Package Builder Methods
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
        
        public async Task<int> AddSeasidePackageAsync(string name, decimal price, string destination, int numberOfDays, 
            string accommodationType, string transportationType)
        {
            var builder = new SeasidePackageBuilder();
            builder
                .SetName(name)
                .SetPrice(price)
                .SetDestination(destination)
                .SetNumberOfDays(numberOfDays);
            
            var package = builder
                .SetAccommodationType(accommodationType)
                .SetTransportationType(transportationType)
                .Build();
            
            return await AddPackageAsync(package);
        }
        
        public async Task<int> AddMountainPackageAsync(string name, decimal price, string destination, int numberOfDays, 
            string accommodationType, string transportationType, List<string> activities)
        {
            var builder = new MountainPackageBuilder();
            builder
                .SetName(name)
                .SetPrice(price)
                .SetDestination(destination)
                .SetNumberOfDays(numberOfDays);
            
            var package = builder
                .SetAccommodationType(accommodationType)
                .SetTransportationType(transportationType)
                .SetActivities(activities)
                .Build();
            
            return await AddPackageAsync(package);
        }
        
        public async Task<int> AddExcursionPackageAsync(string name, decimal price, string destination, int numberOfDays, 
            string transportationType, string guide)
        {
            var builder = new ExcursionPackageBuilder();
            builder
                .SetName(name)
                .SetPrice(price)
                .SetDestination(destination)
                .SetNumberOfDays(numberOfDays);
            
            var package = builder
                .SetTransportationType(transportationType)
                .SetGuide(guide)
                .Build();
            
            return await AddPackageAsync(package);
        }
        
        public async Task<int> AddCruisePackageAsync(string name, decimal price, string destination, int numberOfDays, 
            string ship, string route, DateTime departureDate, string cabinType, string transportationType)
        {
            var builder = new CruisePackageBuilder();
            builder
                .SetName(name)
                .SetPrice(price)
                .SetDestination(destination)
                .SetNumberOfDays(numberOfDays);
            
            var package = builder
                .SetShip(ship)
                .SetRoute(route)
                .SetDepartureDate(departureDate)
                .SetCabinType(cabinType)
                .SetTransportationType(transportationType)
                .Build();
            
            return await AddPackageAsync(package);
        }
    }
}
