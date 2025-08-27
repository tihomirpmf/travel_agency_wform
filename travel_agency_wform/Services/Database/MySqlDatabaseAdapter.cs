using MySql.Data.MySqlClient;
using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders;
using travel_agency_wform.Services.Security;

namespace travel_agency_wform.Services.Database
{
    public class MySqlDatabaseAdapter : IDatabaseAdapter
    {
        private readonly string _connectionString;
        
        public MySqlDatabaseAdapter(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task<bool> InitializeDatabaseAsync()
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                
                var createTablesSql = @"
                    CREATE TABLE IF NOT EXISTS Clients (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        FirstName VARCHAR(50) NOT NULL,
                        LastName VARCHAR(50) NOT NULL,
                        PassportNumber VARCHAR(255) UNIQUE NOT NULL,
                        DateOfBirth DATE NOT NULL,
                        Email VARCHAR(100) NOT NULL,
                        PhoneNumber VARCHAR(255) NOT NULL,
                        CreatedAt DATETIME NOT NULL
                    );
                    
                    CREATE TABLE IF NOT EXISTS TravelPackages (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(100) NOT NULL,
                        Price DECIMAL(10,2) NOT NULL,
                        Type INT NOT NULL,
                        Destination VARCHAR(100) NOT NULL,
                        NumberOfDays INT NOT NULL,
                        AccommodationType VARCHAR(100),
                        TransportationType VARCHAR(100),
                        Guide VARCHAR(100),
                        Ship VARCHAR(100),
                        Route VARCHAR(255),
                        DepartureDate DATE,
                        CabinType VARCHAR(50),
                        Activities TEXT,
                        CreatedAt DATETIME NOT NULL
                    );
                    
                    CREATE TABLE IF NOT EXISTS Reservations (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        ClientId INT NOT NULL,
                        PackageId INT NOT NULL,
                        ReservationDate DATETIME NOT NULL,
                        NumberOfTravelers INT NOT NULL,
                        TotalPrice DECIMAL(10,2) NOT NULL,
                        Status INT NOT NULL,
                        FOREIGN KEY (ClientId) REFERENCES Clients(Id),
                        FOREIGN KEY (PackageId) REFERENCES TravelPackages(Id)
                    );";
                
                using var command = new MySqlCommand(createTablesSql, connection);
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
            
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM Clients ORDER BY LastName, FirstName";
            using var command = new MySqlCommand(sql, connection);
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
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
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM Clients WHERE Id = @Id";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
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
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            // Search by encrypted passport number
            var encryptionService = DataEncryptionService.Instance;
            var encryptedPassport = encryptionService.Encrypt(passportNumber);
            
            var sql = "SELECT * FROM Clients WHERE PassportNumber = @PassportNumber";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@PassportNumber", encryptedPassport);
            
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
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
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"INSERT INTO Clients (FirstName, LastName, PassportNumber, DateOfBirth, Email, PhoneNumber, CreatedAt) 
                       VALUES (@FirstName, @LastName, @PassportNumber, @DateOfBirth, @Email, @PhoneNumber, @CreatedAt);
                       SELECT LAST_INSERT_ID();";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@PassportNumber", client.GetEncryptedPassportNumber());
            command.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
            command.Parameters.AddWithValue("@CreatedAt", client.CreatedAt);
            
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdateClientAsync(Client client)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, 
                       PassportNumber = @PassportNumber, DateOfBirth = @DateOfBirth, 
                       Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", client.Id);
            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@LastName", client.LastName);
            command.Parameters.AddWithValue("@PassportNumber", client.GetEncryptedPassportNumber());
            command.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth);
            command.Parameters.AddWithValue("@Email", client.Email);
            command.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeleteClientAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "DELETE FROM Clients WHERE Id = @Id";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<List<TravelPackage>> GetAllPackagesAsync()
        {
            var packages = new List<TravelPackage>();
            
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages ORDER BY Type, Name";
            using var command = new MySqlCommand(sql, connection);
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var package = CreatePackageFromReader(reader);
                if (package != null)
                {
                    packages.Add(package);
                }
            }
            
            return packages;
        }
        
        public async Task<TravelPackage?> GetPackageByIdAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages WHERE Id = @Id";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return CreatePackageFromReader(reader);
            }
            
            return null;
        }
        
        public async Task<List<TravelPackage>> GetPackagesByTypeAsync(PackageType type)
        {
            var packages = new List<TravelPackage>();
            
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages WHERE Type = @Type ORDER BY Name";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Type", (int)type);
            
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var package = CreatePackageFromReader(reader);
                if (package != null)
                {
                    packages.Add(package);
                }
            }
            
            return packages;
        }
        
        public async Task<int> AddPackageAsync(TravelPackage package)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"INSERT INTO TravelPackages (Name, Price, Type, Destination, NumberOfDays, 
                       AccommodationType, TransportationType, Guide, Ship, Route, DepartureDate, 
                       CabinType, Activities, CreatedAt) 
                       VALUES (@Name, @Price, @Type, @Destination, @NumberOfDays, 
                       @AccommodationType, @TransportationType, @Guide, @Ship, @Route, @DepartureDate, 
                       @CabinType, @Activities, @CreatedAt);
                       SELECT LAST_INSERT_ID();";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", package.Name);
            command.Parameters.AddWithValue("@Price", package.Price);
            command.Parameters.AddWithValue("@Type", (int)package.Type);
            command.Parameters.AddWithValue("@Destination", package.Destination);
            command.Parameters.AddWithValue("@NumberOfDays", package.NumberOfDays);
            command.Parameters.AddWithValue("@CreatedAt", package.CreatedAt);
            
            // Type-specific parameters
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
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"UPDATE TravelPackages SET Name = @Name, Price = @Price, Type = @Type, 
                       Destination = @Destination, NumberOfDays = @NumberOfDays, 
                       AccommodationType = @AccommodationType, TransportationType = @TransportationType, 
                       Guide = @Guide, Ship = @Ship, Route = @Route, DepartureDate = @DepartureDate, 
                       CabinType = @CabinType, Activities = @Activities WHERE Id = @Id";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", package.Id);
            command.Parameters.AddWithValue("@Name", package.Name);
            command.Parameters.AddWithValue("@Price", package.Price);
            command.Parameters.AddWithValue("@Type", (int)package.Type);
            command.Parameters.AddWithValue("@Destination", package.Destination);
            command.Parameters.AddWithValue("@NumberOfDays", package.NumberOfDays);
            
            // Type-specific parameters
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
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "DELETE FROM TravelPackages WHERE Id = @Id";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            var reservations = new List<Reservation>();
            
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, c.FirstName, c.LastName, c.Email, c.PhoneNumber, 
                       p.Name as PackageName, p.Price as PackagePrice, p.Type as PackageType 
                       FROM Reservations r 
                       JOIN Clients c ON r.ClientId = c.Id 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       ORDER BY r.ReservationDate DESC";
            
            using var command = new MySqlCommand(sql, connection);
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var reservation = new Reservation
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate")),
                    NumberOfTravelers = reader.GetInt32(reader.GetOrdinal("NumberOfTravelers")),
                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                    Status = (ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status"))
                };
                
                // Create client
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ClientId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                };
                client.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                reservation.Client = client;
                
                // Create package
                var package = CreatePackageFromReader(reader);
                reservation.Package = package;
                
                reservations.Add(reservation);
            }
            
            return reservations;
        }
        
        public async Task<List<Reservation>> GetReservationsByClientIdAsync(int clientId)
        {
            var reservations = new List<Reservation>();
            
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, c.FirstName, c.LastName, c.Email, c.PhoneNumber, 
                       p.Name as PackageName, p.Price as PackagePrice, p.Type as PackageType 
                       FROM Reservations r 
                       JOIN Clients c ON r.ClientId = c.Id 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       WHERE r.ClientId = @ClientId 
                       ORDER BY r.ReservationDate DESC";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ClientId", clientId);
            
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var reservation = new Reservation
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate")),
                    NumberOfTravelers = reader.GetInt32(reader.GetOrdinal("NumberOfTravelers")),
                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                    Status = (ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status"))
                };
                
                // Create client
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ClientId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                };
                client.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                reservation.Client = client;
                
                // Create package
                var package = CreatePackageFromReader(reader);
                reservation.Package = package;
                
                reservations.Add(reservation);
            }
            
            return reservations;
        }
        
        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, c.FirstName, c.LastName, c.Email, c.PhoneNumber, 
                       p.Name as PackageName, p.Price as PackagePrice, p.Type as PackageType 
                       FROM Reservations r 
                       JOIN Clients c ON r.ClientId = c.Id 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       WHERE r.Id = @Id";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var reservation = new Reservation
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate")),
                    NumberOfTravelers = reader.GetInt32(reader.GetOrdinal("NumberOfTravelers")),
                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                    Status = (ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status"))
                };
                
                // Create client
                var client = new Client
                {
                    Id = reader.GetInt32(reader.GetOrdinal("ClientId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                };
                client.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                reservation.Client = client;
                
                // Create package
                var package = CreatePackageFromReader(reader);
                reservation.Package = package;
                
                return reservation;
            }
            
            return null;
        }
        
        public async Task<int> AddReservationAsync(Reservation reservation)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"INSERT INTO Reservations (ClientId, PackageId, ReservationDate, NumberOfTravelers, TotalPrice, Status) 
                       VALUES (@ClientId, @PackageId, @ReservationDate, @NumberOfTravelers, @TotalPrice, @Status);
                       SELECT LAST_INSERT_ID();";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ClientId", reservation.Client!.Id);
            command.Parameters.AddWithValue("@PackageId", reservation.Package!.Id);
            command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
            command.Parameters.AddWithValue("@NumberOfTravelers", reservation.NumberOfTravelers);
            command.Parameters.AddWithValue("@TotalPrice", reservation.TotalPrice);
            command.Parameters.AddWithValue("@Status", (int)reservation.Status);
            
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = @"UPDATE Reservations SET ClientId = @ClientId, PackageId = @PackageId, 
                       ReservationDate = @ReservationDate, NumberOfTravelers = @NumberOfTravelers, 
                       TotalPrice = @TotalPrice, Status = @Status WHERE Id = @Id";
            
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", reservation.Id);
            command.Parameters.AddWithValue("@ClientId", reservation.Client!.Id);
            command.Parameters.AddWithValue("@PackageId", reservation.Package!.Id);
            command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
            command.Parameters.AddWithValue("@NumberOfTravelers", reservation.NumberOfTravelers);
            command.Parameters.AddWithValue("@TotalPrice", reservation.TotalPrice);
            command.Parameters.AddWithValue("@Status", (int)reservation.Status);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> CancelReservationAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "UPDATE Reservations SET Status = @Status WHERE Id = @Id";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Status", (int)ReservationStatus.Cancelled);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeleteReservationAsync(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            var sql = "DELETE FROM Reservations WHERE Id = @Id";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            var rows = await command.ExecuteNonQueryAsync();
            return rows > 0;
        }
        
        public async Task<List<string>> GetAllDestinationsAsync()
        {
            var destinations = new List<string>();
            
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var sql = "SELECT DISTINCT Destination FROM TravelPackages ORDER BY Destination";
            using var command = new MySqlCommand(sql, connection);
            using var reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                destinations.Add(reader.GetString(reader.GetOrdinal("Destination")));
            }
            
            return destinations;
        }
        
        public async Task<bool> CreateBackupAsync()
        {
            var template = new Templates.MySqlBackupTemplate(_connectionString);
            return await template.RunAsync();
        }
        
        private async Task<string> GenerateBackupSqlAsync(MySqlConnection connection)
        {
            var backupSql = new System.Text.StringBuilder();
            backupSql.AppendLine("-- Travel Agency Database Backup");
            backupSql.AppendLine($"-- Generated on: {DateTime.Now}");
            backupSql.AppendLine();
            
            // Backup clients
            backupSql.AppendLine("-- Clients");
            var clientSql = "SELECT * FROM Clients";
            using var clientCommand = new MySqlCommand(clientSql, connection);
            using var clientReader = await clientCommand.ExecuteReaderAsync();
            
            while (await clientReader.ReadAsync())
            {
                backupSql.AppendLine($"INSERT INTO Clients VALUES ({clientReader.GetInt32(clientReader.GetOrdinal("Id"))}, '{clientReader.GetString(clientReader.GetOrdinal("FirstName"))}', '{clientReader.GetString(clientReader.GetOrdinal("LastName"))}', '{clientReader.GetString(clientReader.GetOrdinal("PassportNumber"))}', '{clientReader.GetDateTime(clientReader.GetOrdinal("DateOfBirth")):yyyy-MM-dd}', '{clientReader.GetString(clientReader.GetOrdinal("Email"))}', '{clientReader.GetString(clientReader.GetOrdinal("PhoneNumber"))}', '{clientReader.GetDateTime(clientReader.GetOrdinal("CreatedAt")):yyyy-MM-dd HH:mm:ss}');");
            }
            
            return backupSql.ToString();
        }
        
        private TravelPackage? CreatePackageFromReader(MySqlDataReader reader)
        {
            var type = (PackageType)reader.GetInt32(reader.GetOrdinal("Type"));
            TravelPackage? package = type switch
            {
                PackageType.Seaside => new SeasidePackage(),
                PackageType.Mountain => new MountainPackage(),
                PackageType.Excursion => new ExcursionPackage(),
                PackageType.Cruise => new CruisePackage(),
                _ => null
            };
            
            if (package == null) return null;
            
            package.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            package.Name = reader.GetString(reader.GetOrdinal("Name"));
            package.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
            package.Destination = reader.GetString(reader.GetOrdinal("Destination"));
            package.NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays"));
            package.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));
            
            // Set type-specific properties
            switch (package)
            {
                case SeasidePackage seaside:
                    seaside.AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType"));
                    seaside.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    break;
                case MountainPackage mountain:
                    mountain.AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType"));
                    mountain.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    mountain.Activities = reader.IsDBNull(reader.GetOrdinal("Activities")) ? new List<string>() : reader.GetString(reader.GetOrdinal("Activities")).Split(',').ToList();
                    break;
                case ExcursionPackage excursion:
                    excursion.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    excursion.Guide = reader.IsDBNull(reader.GetOrdinal("Guide")) ? "" : reader.GetString(reader.GetOrdinal("Guide"));
                    break;
                case CruisePackage cruise:
                    cruise.Ship = reader.IsDBNull(reader.GetOrdinal("Ship")) ? "" : reader.GetString(reader.GetOrdinal("Ship"));
                    cruise.Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? "" : reader.GetString(reader.GetOrdinal("Route"));
                    cruise.DepartureDate = reader.IsDBNull(reader.GetOrdinal("DepartureDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DepartureDate"));
                    cruise.CabinType = reader.IsDBNull(reader.GetOrdinal("CabinType")) ? "" : reader.GetString(reader.GetOrdinal("CabinType"));
                    cruise.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    break;
            }
            
            return package;
        }
        
        private string? GetAccommodationType(TravelPackage package) => package switch
        {
            SeasidePackage seaside => seaside.AccommodationType,
            MountainPackage mountain => mountain.AccommodationType,
            _ => null
        };
        
        private string? GetTransportationType(TravelPackage package) => package switch
        {
            SeasidePackage seaside => seaside.TransportationType,
            MountainPackage mountain => mountain.TransportationType,
            ExcursionPackage excursion => excursion.TransportationType,
            _ => null
        };
        
        private string? GetGuide(TravelPackage package) => package switch
        {
            ExcursionPackage excursion => excursion.Guide,
            _ => null
        };
        
        private string? GetShip(TravelPackage package) => package switch
        {
            CruisePackage cruise => cruise.Ship,
            _ => null
        };
        
        private string? GetRoute(TravelPackage package) => package switch
        {
            CruisePackage cruise => cruise.Route,
            _ => null
        };
        
        private DateTime? GetDepartureDate(TravelPackage package) => package switch
        {
            CruisePackage cruise => cruise.DepartureDate,
            _ => null
        };
        
        private string? GetCabinType(TravelPackage package) => package switch
        {
            CruisePackage cruise => cruise.CabinType,
            _ => null
        };
        
        private string? GetActivities(TravelPackage package) => package switch
        {
            MountainPackage mountain => string.Join(",", mountain.Activities),
            _ => null
        };
    }
}
