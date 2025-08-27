using Microsoft.Data.Sqlite;
using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders;

namespace travel_agency_wform.Services.Database
{
    public class SqliteDatabaseAdapter : IDatabaseAdapter
    {
        private readonly string _connectionString;
        
        public SqliteDatabaseAdapter(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task<bool> InitializeDatabaseAsync()
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                await connection.OpenAsync();
                
                var createTablesSql = @"
                    CREATE TABLE IF NOT EXISTS Clients (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        PassportNumber TEXT UNIQUE NOT NULL,
                        DateOfBirth TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        PhoneNumber TEXT NOT NULL,
                        CreatedAt TEXT NOT NULL
                    );
                    
                    CREATE TABLE IF NOT EXISTS TravelPackages (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL,
                        Type INTEGER NOT NULL,
                        Destination TEXT NOT NULL,
                        NumberOfDays INTEGER NOT NULL,
                        CreatedAt TEXT NOT NULL,
                        AccommodationType TEXT,
                        TransportationType TEXT,
                        Guide TEXT,
                        Ship TEXT,
                        Route TEXT,
                        DepartureDate TEXT,
                        CabinType TEXT,
                        Activities TEXT
                    );
                    
                    CREATE TABLE IF NOT EXISTS Reservations (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClientId INTEGER NOT NULL,
                        PackageId INTEGER NOT NULL,
                        ReservationDate TEXT NOT NULL,
                        NumberOfTravelers INTEGER NOT NULL,
                        TotalPrice REAL NOT NULL,
                        Status INTEGER NOT NULL,
                        FOREIGN KEY (ClientId) REFERENCES Clients (Id),
                        FOREIGN KEY (PackageId) REFERENCES TravelPackages (Id)
                    );";
                
                using var command = new SqliteCommand(createTablesSql, connection);
                await command.ExecuteNonQueryAsync();
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<List<Client>> GetAllClientsAsync()
        {
            var clients = new List<Client>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM Clients ORDER BY LastName, FirstName";
            using var command = new SqliteCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = DateTime.Parse(reader.GetString(reader.GetOrdinal("DateOfBirth"))),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))
                };
                
                // Handle encrypted data
                client.SetEncryptedPassportNumber(reader.GetString(reader.GetOrdinal("PassportNumber")));
                
                clients.Add(client);
            }
            
            return clients;
        }
        
        public async Task<Client?> GetClientByIdAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM Clients WHERE Id = @Id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = DateTime.Parse(reader.GetString(reader.GetOrdinal("DateOfBirth"))),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))
                };
                
                // Handle encrypted data
                client.SetEncryptedPassportNumber(reader.GetString(reader.GetOrdinal("PassportNumber")));
                
                return client;
            }
            
            return null;
        }
        
        public async Task<Client?> GetClientByPassportAsync(string passportNumber)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            // Search by encrypted passport number
            var encryptionService = travel_agency_wform.Services.Security.DataEncryptionService.Instance;
            var encryptedPassport = encryptionService.Encrypt(passportNumber);
            
            var sql = "SELECT * FROM Clients WHERE PassportNumber = @PassportNumber";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@PassportNumber", encryptedPassport);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = DateTime.Parse(reader.GetString(reader.GetOrdinal("DateOfBirth"))),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))
                };
                
                // Handle encrypted data
                client.SetEncryptedPassportNumber(reader.GetString(reader.GetOrdinal("PassportNumber")));
                
                return client;
            }
            
            return null;
        }
        
        public async Task<int> AddClientAsync(Client client)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"INSERT INTO Clients (FirstName, LastName, PassportNumber, DateOfBirth, Email, PhoneNumber, CreatedAt) 
                       VALUES (@FirstName, @LastName, @PassportNumber, @DateOfBirth, @Email, @PhoneNumber, @CreatedAt);
                       SELECT last_insert_rowid();";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@PassportNumber", client.GetEncryptedPassportNumber());
            command.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
            command.Parameters.AddWithValue("@CreatedAt", client.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
            
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdateClientAsync(Client client)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, 
                       PassportNumber = @PassportNumber, DateOfBirth = @DateOfBirth, 
                       Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", client.Id);
            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@PassportNumber", client.GetEncryptedPassportNumber());
            command.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeleteClientAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "DELETE FROM Clients WHERE Id = @Id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<List<TravelPackage>> GetAllPackagesAsync()
        {
            var packages = new List<TravelPackage>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages ORDER BY Type, Name";
            using var command = new SqliteCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var package = CreatePackageFromReader(reader);
                if (package != null)
                    packages.Add(package);
            }
            
            return packages;
        }
        
        public async Task<TravelPackage?> GetPackageByIdAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages WHERE Id = @Id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return CreatePackageFromReader(reader);
            }
            
            return null;
        }
        
        public async Task<List<TravelPackage>> GetPackagesByTypeAsync(PackageType type)
        {
            var packages = new List<TravelPackage>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages WHERE Type = @Type ORDER BY Name";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Type", (int)type);
            
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var package = CreatePackageFromReader(reader);
                if (package != null)
                    packages.Add(package);
            }
            
            return packages;
        }
        
        public async Task<int> AddPackageAsync(TravelPackage package)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"INSERT INTO TravelPackages (Name, Price, Type, Destination, NumberOfDays, CreatedAt, 
                       AccommodationType, TransportationType, Guide, Ship, Route, DepartureDate, CabinType, Activities) 
                       VALUES (@Name, @Price, @Type, @Destination, @NumberOfDays, @CreatedAt, 
                       @AccommodationType, @TransportationType, @Guide, @Ship, @Route, @DepartureDate, @CabinType, @Activities);
                       SELECT last_insert_rowid();";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", package.Name);
            command.Parameters.AddWithValue("@Price", package.Price);
            command.Parameters.AddWithValue("@Type", (int)package.Type);
            command.Parameters.AddWithValue("@Destination", package.Destination);
            command.Parameters.AddWithValue("@NumberOfDays", package.NumberOfDays);
            command.Parameters.AddWithValue("@CreatedAt", package.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
            
            // Add type-specific parameters
            command.Parameters.AddWithValue("@AccommodationType", GetAccommodationType(package));
            command.Parameters.AddWithValue("@TransportationType", GetTransportationType(package));
            command.Parameters.AddWithValue("@Guide", GetGuide(package));
            command.Parameters.AddWithValue("@Ship", GetShip(package));
            command.Parameters.AddWithValue("@Route", GetRoute(package));
            command.Parameters.AddWithValue("@DepartureDate", GetDepartureDate(package));
            command.Parameters.AddWithValue("@CabinType", GetCabinType(package));
            command.Parameters.AddWithValue("@Activities", GetActivities(package));
            
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdatePackageAsync(TravelPackage package)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"UPDATE TravelPackages SET Name = @Name, Price = @Price, Type = @Type, 
                       Destination = @Destination, NumberOfDays = @NumberOfDays, 
                       AccommodationType = @AccommodationType, TransportationType = @TransportationType, 
                       Guide = @Guide, Ship = @Ship, Route = @Route, DepartureDate = @DepartureDate, 
                       CabinType = @CabinType, Activities = @Activities WHERE Id = @Id";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", package.Id);
            command.Parameters.AddWithValue("@Name", package.Name);
            command.Parameters.AddWithValue("@Price", package.Price);
            command.Parameters.AddWithValue("@Type", (int)package.Type);
            command.Parameters.AddWithValue("@Destination", package.Destination);
            command.Parameters.AddWithValue("@NumberOfDays", package.NumberOfDays);
            
            // Add type-specific parameters
            command.Parameters.AddWithValue("@AccommodationType", GetAccommodationType(package));
            command.Parameters.AddWithValue("@TransportationType", GetTransportationType(package));
            command.Parameters.AddWithValue("@Guide", GetGuide(package));
            command.Parameters.AddWithValue("@Ship", GetShip(package));
            command.Parameters.AddWithValue("@Route", GetRoute(package));
            command.Parameters.AddWithValue("@DepartureDate", GetDepartureDate(package));
            command.Parameters.AddWithValue("@CabinType", GetCabinType(package));
            command.Parameters.AddWithValue("@Activities", GetActivities(package));
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeletePackageAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "DELETE FROM TravelPackages WHERE Id = @Id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            var reservations = new List<Reservation>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, c.FirstName, c.LastName, p.Name as PackageName 
                       FROM Reservations r 
                       JOIN Clients c ON r.ClientId = c.Id 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       ORDER BY r.ReservationDate DESC";
            
            using var command = new SqliteCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                reservations.Add(new Reservation
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ClientId = reader.GetInt32(reader.GetOrdinal("ClientId")),
                    PackageId = reader.GetInt32(reader.GetOrdinal("PackageId")),
                    ReservationDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("ReservationDate"))),
                    NumberOfTravelers = reader.GetInt32(reader.GetOrdinal("NumberOfTravelers")),
                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                    Status = (ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status")),
                    Client = new Client { FirstName = reader.GetString(reader.GetOrdinal("FirstName")), LastName = reader.GetString(reader.GetOrdinal("LastName")) },
                    Package = new SeasidePackage { Name = reader.GetString(reader.GetOrdinal("PackageName")) }
                });
            }
            
            return reservations;
        }
        
        public async Task<List<Reservation>> GetReservationsByClientIdAsync(int clientId)
        {
            var reservations = new List<Reservation>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, p.Name as PackageName 
                       FROM Reservations r 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       WHERE r.ClientId = @ClientId 
                       ORDER BY r.ReservationDate DESC";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@ClientId", clientId);
            
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                reservations.Add(new Reservation
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ClientId = reader.GetInt32(reader.GetOrdinal("ClientId")),
                    PackageId = reader.GetInt32(reader.GetOrdinal("PackageId")),
                    ReservationDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("ReservationDate"))),
                    NumberOfTravelers = reader.GetInt32(reader.GetOrdinal("NumberOfTravelers")),
                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                    Status = (ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status")),
                    Package = new SeasidePackage { Name = reader.GetString(reader.GetOrdinal("PackageName")) }
                });
            }
            
            return reservations;
        }
        
        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, c.FirstName, c.LastName, p.Name as PackageName 
                       FROM Reservations r 
                       JOIN Clients c ON r.ClientId = c.Id 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       WHERE r.Id = @Id";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Reservation
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ClientId = reader.GetInt32(reader.GetOrdinal("ClientId")),
                    PackageId = reader.GetInt32(reader.GetOrdinal("PackageId")),
                    ReservationDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("ReservationDate"))),
                    NumberOfTravelers = reader.GetInt32(reader.GetOrdinal("NumberOfTravelers")),
                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                    Status = (ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status")),
                    Client = new Client { FirstName = reader.GetString(reader.GetOrdinal("FirstName")), LastName = reader.GetString(reader.GetOrdinal("LastName")) },
                    Package = new SeasidePackage { Name = reader.GetString(reader.GetOrdinal("PackageName")) }
                };
            }
            
            return null;
        }
        
        public async Task<int> AddReservationAsync(Reservation reservation)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"INSERT INTO Reservations (ClientId, PackageId, ReservationDate, NumberOfTravelers, TotalPrice, Status) 
                       VALUES (@ClientId, @PackageId, @ReservationDate, @NumberOfTravelers, @TotalPrice, @Status);
                       SELECT last_insert_rowid();";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@ClientId", reservation.ClientId);
            command.Parameters.AddWithValue("@PackageId", reservation.PackageId);
            command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@NumberOfTravelers", reservation.NumberOfTravelers);
            command.Parameters.AddWithValue("@TotalPrice", reservation.TotalPrice);
            command.Parameters.AddWithValue("@Status", (int)reservation.Status);
            
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"UPDATE Reservations SET ClientId = @ClientId, PackageId = @PackageId, 
                       ReservationDate = @ReservationDate, NumberOfTravelers = @NumberOfTravelers, 
                       TotalPrice = @TotalPrice, Status = @Status WHERE Id = @Id";
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", reservation.Id);
            command.Parameters.AddWithValue("@ClientId", reservation.ClientId);
            command.Parameters.AddWithValue("@PackageId", reservation.PackageId);
            command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@NumberOfTravelers", reservation.NumberOfTravelers);
            command.Parameters.AddWithValue("@TotalPrice", reservation.TotalPrice);
            command.Parameters.AddWithValue("@Status", (int)reservation.Status);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> CancelReservationAsync(int id)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                await connection.OpenAsync();
                
                var sql = "UPDATE Reservations SET Status = @Status WHERE Id = @Id";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Status", (int)ReservationStatus.Cancelled);
                
                var rowsAffected = await command.ExecuteNonQueryAsync();
                
                // Log the operation for debugging
                System.Diagnostics.Debug.WriteLine($"CancelReservationAsync: Reservation ID {id}, Rows affected: {rowsAffected}");
                
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CancelReservationAsync error: {ex.Message}");
                throw;
            }
        }
        
        public async Task<bool> DeleteReservationAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            var sql = "DELETE FROM Reservations WHERE Id = @Id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            var rows = await command.ExecuteNonQueryAsync();
            return rows > 0;
        }
        
        public async Task<List<string>> GetAllDestinationsAsync()
        {
            var destinations = new List<string>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT DISTINCT Destination FROM TravelPackages ORDER BY Destination";
            using var command = new SqliteCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                destinations.Add(reader.GetString(reader.GetOrdinal("Destination")));
            }
            
            return destinations;
        }
        
        public async Task<bool> CreateBackupAsync()
        {
            var template = new Templates.SqliteBackupTemplate(_connectionString);
            return await template.RunAsync();
        }
        
        private TravelPackage? CreatePackageFromReader(SqliteDataReader reader)
        {
            var type = (PackageType)reader.GetInt32(reader.GetOrdinal("Type"));
            
            switch (type)
            {
                case PackageType.Seaside:
                    return new SeasidePackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType")),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"))
                    };
                    
                case PackageType.Mountain:
                    var activities = reader.IsDBNull(reader.GetOrdinal("Activities")) ? "" : reader.GetString(reader.GetOrdinal("Activities"));
                    return new MountainPackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType")),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType")),
                        Activities = string.IsNullOrEmpty(activities) ? new List<string>() : activities.Split(',').ToList()
                    };
                    
                case PackageType.Excursion:
                    return new ExcursionPackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType")),
                        Guide = reader.IsDBNull(reader.GetOrdinal("Guide")) ? "" : reader.GetString(reader.GetOrdinal("Guide"))
                    };
                    
                case PackageType.Cruise:
                    return new CruisePackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        Ship = reader.IsDBNull(reader.GetOrdinal("Ship")) ? "" : reader.GetString(reader.GetOrdinal("Ship")),
                        Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? "" : reader.GetString(reader.GetOrdinal("Route")),
                        DepartureDate = reader.IsDBNull(reader.GetOrdinal("DepartureDate")) ? DateTime.Now : DateTime.Parse(reader.GetString(reader.GetOrdinal("DepartureDate"))),
                        CabinType = reader.IsDBNull(reader.GetOrdinal("CabinType")) ? "" : reader.GetString(reader.GetOrdinal("CabinType")),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"))
                    };
                    
                default:
                    return null;
            }
        }
        
        private string GetAccommodationType(TravelPackage package)
        {
            return package switch
            {
                SeasidePackage seaside => seaside.AccommodationType,
                MountainPackage mountain => mountain.AccommodationType,
                _ => ""
            };
        }
        
        private string GetTransportationType(TravelPackage package)
        {
            return package switch
            {
                SeasidePackage seaside => seaside.TransportationType,
                MountainPackage mountain => mountain.TransportationType,
                ExcursionPackage excursion => excursion.TransportationType,
                CruisePackage cruise => cruise.TransportationType,
                _ => ""
            };
        }
        
        private string GetGuide(TravelPackage package)
        {
            return package is ExcursionPackage excursion ? excursion.Guide : "";
        }
        
        private string GetShip(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.Ship : "";
        }
        
        private string GetRoute(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.Route : "";
        }
        
        private string GetDepartureDate(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.DepartureDate.ToString("yyyy-MM-dd") : "";
        }
        
        private string GetCabinType(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.CabinType : "";
        }
        
        private string GetActivities(TravelPackage package)
        {
            return package is MountainPackage mountain ? string.Join(",", mountain.Activities) : "";
        }
    }
}
