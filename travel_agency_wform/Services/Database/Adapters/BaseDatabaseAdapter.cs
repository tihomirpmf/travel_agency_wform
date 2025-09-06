using System.Data.Common;
using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders.PackageBuilders;
using travel_agency_wform.Services.Builders;

namespace travel_agency_wform.Services.Database.Adapters
{
    public abstract class BaseDatabaseAdapter : IDatabaseAdapter
    {
        protected readonly IDatabaseConnection _connectionFactory;
        
        protected BaseDatabaseAdapter(IDatabaseConnection connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        
        // Abstract methods for database-specific operations
        protected virtual DbConnection CreateConnection() => _connectionFactory.CreateConnection();
        protected abstract DbCommand CreateCommand(string sql, DbConnection connection);
        protected abstract void AddParameter(DbCommand command, string name, object value);
        protected abstract string GetLastInsertIdSql();
        protected abstract string GetAutoIncrementSql();
        protected abstract string GetDateTimeFormat();
        protected abstract DateTime ParseDateTime(string value);
        protected abstract DateTime GetDateTime(DbDataReader reader, string columnName);
        protected abstract string GetBackupTemplateType();
        
        // Template method for initialization
        public async Task<bool> InitializeDatabaseAsync()
        {
            try
            {
                using var connection = CreateConnection();
                await connection.OpenAsync();
                
                var createTablesSql = GetCreateTablesSql();
                using var command = CreateCommand(createTablesSql, connection);
                await command.ExecuteNonQueryAsync();
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        protected virtual string GetCreateTablesSql()
        {
            return $@"
                CREATE TABLE IF NOT EXISTS Clients (
                    Id {GetAutoIncrementSql()},
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    PassportNumber TEXT UNIQUE NOT NULL,
                    DateOfBirth TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    PhoneNumber TEXT NOT NULL,
                    CreatedAt TEXT NOT NULL
                );
                
                CREATE TABLE IF NOT EXISTS TravelPackages (
                    Id {GetAutoIncrementSql()},
                    Name TEXT NOT NULL,
                    Price REAL NOT NULL,
                    Type INTEGER NOT NULL,
                    Destination TEXT,
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
                    Id {GetAutoIncrementSql()},
                    ClientId INTEGER NOT NULL,
                    PackageId INTEGER NOT NULL,
                    NumberOfTravelers INTEGER NOT NULL,
                    TotalPrice REAL NOT NULL,
                    Status INTEGER NOT NULL,
                    FOREIGN KEY (ClientId) REFERENCES Clients (Id),
                    FOREIGN KEY (PackageId) REFERENCES TravelPackages (Id)
                );";
        }
        
        // Common CRUD operations
        public async Task<List<Client>> GetAllClientsAsync()
        {
            var clients = new List<Client>();
            
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM Clients ORDER BY LastName, FirstName";
            using var command = CreateCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                var client = CreateClientFromReader(reader);
                clients.Add(client);
            }
            
            return clients;
        }
        
        public async Task<Client?> GetClientByIdAsync(int id)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM Clients WHERE Id = @Id";
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@Id", id);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return CreateClientFromReader(reader);
            }
            
            return null;
        }
        public async Task<int> AddClientAsync(Client client)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = $@"INSERT INTO Clients (FirstName, LastName, PassportNumber, DateOfBirth, Email, PhoneNumber, CreatedAt) 
                       VALUES (@FirstName, @LastName, @PassportNumber, @DateOfBirth, @Email, @PhoneNumber, @CreatedAt);
                       {GetLastInsertIdSql()};";
            
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@FirstName", client.FirstName);
            AddParameter(command, "@LastName", client.LastName);
            AddParameter(command, "@PassportNumber", client.GetEncryptedPassportNumber());
            AddParameter(command, "@DateOfBirth", client.DateOfBirth.ToString("yyyy-MM-dd"));
            AddParameter(command, "@Email", client.Email);
            AddParameter(command, "@PhoneNumber", client.PhoneNumber);
            AddParameter(command, "@CreatedAt", client.CreatedAt.ToString(GetDateTimeFormat()));
            
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        
        // Package operations
        public async Task<List<TravelPackage>> GetAllPackagesAsync()
        {
            var packages = new List<TravelPackage>();
            
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages ORDER BY Type, Name";
            using var command = CreateCommand(sql, connection);
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
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = "SELECT * FROM TravelPackages WHERE Id = @Id";
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@Id", id);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return CreatePackageFromReader(reader);
            }
            
            return null;
        }
        public async Task<int> AddPackageAsync(TravelPackage package)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = $@"INSERT INTO TravelPackages (Name, Price, Type, Destination, NumberOfDays, CreatedAt, 
                       AccommodationType, TransportationType, Guide, Ship, Route, DepartureDate, CabinType, Activities) 
                       VALUES (@Name, @Price, @Type, @Destination, @NumberOfDays, @CreatedAt, 
                       @AccommodationType, @TransportationType, @Guide, @Ship, @Route, @DepartureDate, @CabinType, @Activities);
                       {GetLastInsertIdSql()};";
            
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@Name", package.Name);
            AddParameter(command, "@Price", package.Price);
            AddParameter(command, "@Type", (int)package.Type);
            // Destination: for cruises store empty string to support existing NOT NULL schemas
            AddParameter(command, "@Destination", package.Type == PackageType.Cruise ? "" : package.Destination);
            AddParameter(command, "@NumberOfDays", package.NumberOfDays);
            AddParameter(command, "@CreatedAt", package.CreatedAt.ToString(GetDateTimeFormat()));
            
            // Add type-specific parameters
            AddParameter(command, "@AccommodationType", GetAccommodationType(package));
            AddParameter(command, "@TransportationType", GetTransportationType(package));
            AddParameter(command, "@Guide", GetGuide(package));
            AddParameter(command, "@Ship", GetShip(package));
            AddParameter(command, "@Route", GetRoute(package));
            AddParameter(command, "@DepartureDate", GetDepartureDate(package));
            AddParameter(command, "@CabinType", GetCabinType(package));
            AddParameter(command, "@Activities", GetActivities(package));
            
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
        
        // Reservation operations
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            var reservations = new List<Reservation>();
            
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, c.FirstName, c.LastName, p.Name as PackageName 
                       FROM Reservations r 
                       JOIN Clients c ON r.ClientId = c.Id 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       ORDER BY r.Id DESC";
            
            using var command = CreateCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                reservations.Add(CreateReservationFromReader(reader));
            }
            
            return reservations;
        }
        
        public async Task<List<Reservation>> GetReservationsByClientIdAsync(int clientId)
        {
            var reservations = new List<Reservation>();
            
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, p.Name as PackageName 
                       FROM Reservations r 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       WHERE r.ClientId = @ClientId 
                       ORDER BY r.Id DESC";
            
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@ClientId", clientId);
            
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                reservations.Add(CreateReservationFromReader(reader));
            }
            
            return reservations;
        }
        
        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = @"SELECT r.*, c.FirstName, c.LastName, p.Name as PackageName 
                       FROM Reservations r 
                       JOIN Clients c ON r.ClientId = c.Id 
                       JOIN TravelPackages p ON r.PackageId = p.Id 
                       WHERE r.Id = @Id";
            
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@Id", id);
            
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return CreateReservationFromReader(reader);
            }
            
            return null;
        }
        
        public async Task<int> AddReservationAsync(Reservation reservation)
        {
            try
            {
                using var connection = CreateConnection();
                await connection.OpenAsync();
                
                var sql = $@"INSERT INTO Reservations (ClientId, PackageId, NumberOfTravelers, TotalPrice, Status) 
                           VALUES (@ClientId, @PackageId, @NumberOfTravelers, @TotalPrice, @Status);
                           {GetLastInsertIdSql()};";
                
                using var command = CreateCommand(sql, connection);
                AddParameter(command, "@ClientId", reservation.ClientId);
                AddParameter(command, "@PackageId", reservation.PackageId);
                AddParameter(command, "@NumberOfTravelers", reservation.NumberOfTravelers);
                AddParameter(command, "@TotalPrice", reservation.TotalPrice);
                AddParameter(command, "@Status", (int)reservation.Status);
                
                var result = await command.ExecuteScalarAsync();
                var reservationId = Convert.ToInt32(result);
                return reservationId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = @"UPDATE Reservations SET ClientId = @ClientId, PackageId = @PackageId, 
                       NumberOfTravelers = @NumberOfTravelers, 
                       TotalPrice = @TotalPrice, Status = @Status WHERE Id = @Id";
            
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@Id", reservation.Id);
            AddParameter(command, "@ClientId", reservation.ClientId);
            AddParameter(command, "@PackageId", reservation.PackageId);
            AddParameter(command, "@NumberOfTravelers", reservation.NumberOfTravelers);
            AddParameter(command, "@TotalPrice", reservation.TotalPrice);
            AddParameter(command, "@Status", (int)reservation.Status);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> CancelReservationAsync(int id)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = "UPDATE Reservations SET Status = @Status WHERE Id = @Id";
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@Id", id);
            AddParameter(command, "@Status", (int)ReservationStatus.Cancelled);
            
            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeleteReservationAsync(int id)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            var sql = "DELETE FROM Reservations WHERE Id = @Id";
            using var command = CreateCommand(sql, connection);
            AddParameter(command, "@Id", id);
            var rows = await command.ExecuteNonQueryAsync();
            return rows > 0;
        }
        
        public async Task<List<string>> GetAllDestinationsAsync()
        {
            var destinations = new List<string>();
            
            using var connection = CreateConnection();
            await connection.OpenAsync();
            
            var sql = "SELECT DISTINCT Destination FROM TravelPackages WHERE Destination IS NOT NULL AND Destination <> '' ORDER BY Destination";
            using var command = CreateCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                destinations.Add(reader.GetString(reader.GetOrdinal("Destination")));
            }
            
            return destinations;
        }
        
        public async Task<bool> CreateBackupAsync()
        {
            var templateType = GetBackupTemplateType();
            if (templateType == "Sqlite")
            {
                var template = new Templates.SqliteBackupTemplate(_connectionFactory.GetConnectionString());
                return await template.RunAsync();
            }
            else
            {
                var template = new Templates.MySqlBackupTemplate(_connectionFactory.GetConnectionString());
                return await template.RunAsync();
            }
        }
        
        // Helper methods
        protected virtual Client CreateClientFromReader(DbDataReader reader)
        {
            var client = new Client
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                DateOfBirth = GetDateTime(reader, "DateOfBirth"),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                CreatedAt = GetDateTime(reader, "CreatedAt"),
                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))
            };
            
            // Handle encrypted data
            client.SetEncryptedPassportNumber(reader.GetString(reader.GetOrdinal("PassportNumber")));
            
            return client;
        }
        
        // Helper methods for null-checking
        protected virtual string GetStringOrEmpty(DbDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? "" : reader.GetString(reader.GetOrdinal(columnName));
        }
        
        protected virtual DateTime GetDateTimeOrMinValue(DbDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? DateTime.MinValue : GetDateTime(reader, columnName);
        }
        
        protected virtual List<string> GetStringListOrEmpty(DbDataReader reader, string columnName)
        {
            var value = GetStringOrEmpty(reader, columnName);
            return string.IsNullOrEmpty(value) ? new List<string>() : value.Split(',').ToList();
        }
        
        // Template method for creating packages from reader
        protected virtual TravelPackage? CreatePackageFromReader(DbDataReader reader)
        {
            var type = (PackageType)reader.GetInt32(reader.GetOrdinal("Type"));
            
            switch (type)
            {
                case PackageType.Seaside:
                    var seasideBuilder = new SeasidePackageBuilder();
                    seasideBuilder.SetId(reader.GetInt32(reader.GetOrdinal("Id")))
                                 .SetName(reader.GetString(reader.GetOrdinal("Name")))
                                 .SetPrice(reader.GetDecimal(reader.GetOrdinal("Price")))
                                 .SetDestination(reader.GetString(reader.GetOrdinal("Destination")))
                                 .SetNumberOfDays(reader.GetInt32(reader.GetOrdinal("NumberOfDays")))
                                 .SetCreatedAt(GetDateTime(reader, "CreatedAt"))
                                 .SetAccommodationType(GetStringOrEmpty(reader, "AccommodationType"))
                                 .SetTransportationType(GetStringOrEmpty(reader, "TransportationType"));
                    return seasideBuilder.Build();
                    
                case PackageType.Mountain:
                    var mountainBuilder = new MountainPackageBuilder();
                    mountainBuilder.SetId(reader.GetInt32(reader.GetOrdinal("Id")))
                                  .SetName(reader.GetString(reader.GetOrdinal("Name")))
                                  .SetPrice(reader.GetDecimal(reader.GetOrdinal("Price")))
                                  .SetDestination(reader.GetString(reader.GetOrdinal("Destination")))
                                  .SetNumberOfDays(reader.GetInt32(reader.GetOrdinal("NumberOfDays")))
                                  .SetCreatedAt(GetDateTime(reader, "CreatedAt"))
                                  .SetAccommodationType(GetStringOrEmpty(reader, "AccommodationType"))
                                  .SetTransportationType(GetStringOrEmpty(reader, "TransportationType"))
                                  .SetActivities(GetStringListOrEmpty(reader, "Activities"));
                    return mountainBuilder.Build();
                    
                case PackageType.Excursion:
                    var excursionBuilder = new ExcursionPackageBuilder();
                    excursionBuilder.SetId(reader.GetInt32(reader.GetOrdinal("Id")))
                                   .SetName(reader.GetString(reader.GetOrdinal("Name")))
                                   .SetPrice(reader.GetDecimal(reader.GetOrdinal("Price")))
                                   .SetDestination(reader.GetString(reader.GetOrdinal("Destination")))
                                   .SetNumberOfDays(reader.GetInt32(reader.GetOrdinal("NumberOfDays")))
                                   .SetCreatedAt(GetDateTime(reader, "CreatedAt"))
                                   .SetTransportationType(GetStringOrEmpty(reader, "TransportationType"))
                                   .SetGuide(GetStringOrEmpty(reader, "Guide"));
                    return excursionBuilder.Build();
                    
                case PackageType.Cruise:
                    var cruiseBuilder = new CruisePackageBuilder();
                    cruiseBuilder.SetId(reader.GetInt32(reader.GetOrdinal("Id")))
                                .SetName(reader.GetString(reader.GetOrdinal("Name")))
                                .SetPrice(reader.GetDecimal(reader.GetOrdinal("Price")))
                                .SetNumberOfDays(reader.GetInt32(reader.GetOrdinal("NumberOfDays")))
                                .SetCreatedAt(GetDateTime(reader, "CreatedAt"))
                                .SetShip(GetStringOrEmpty(reader, "Ship"))
                                .SetRoute(GetStringOrEmpty(reader, "Route"))
                                .SetDepartureDate(GetDateTimeOrMinValue(reader, "DepartureDate"))
                                .SetCabinType(GetStringOrEmpty(reader, "CabinType"));
                    return cruiseBuilder.Build();
                    
                default:
                    throw new ArgumentException($"Unknown package type: {type}");
            }
        }
        
        protected virtual Reservation CreateReservationFromReader(DbDataReader reader)
        {
            return new ReservationBuilder()
                .SetId(reader.GetInt32(reader.GetOrdinal("Id")))
                .SetClientId(reader.GetInt32(reader.GetOrdinal("ClientId")))
                .SetPackageId(reader.GetInt32(reader.GetOrdinal("PackageId")))
                .SetNumberOfTravelers(reader.GetInt32(reader.GetOrdinal("NumberOfTravelers")))
                .SetTotalPrice(reader.GetDecimal(reader.GetOrdinal("TotalPrice")))
                .SetStatus((ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status")))
                .SetClient(new Client { FirstName = reader.GetString(reader.GetOrdinal("FirstName")), LastName = reader.GetString(reader.GetOrdinal("LastName")) })
                .SetPackage(new SeasidePackage { Name = reader.GetString(reader.GetOrdinal("PackageName")) })
                .Build();
        }
        
        // Package type-specific helper methods
        protected virtual string GetAccommodationType(TravelPackage package)
        {
            return package switch
            {
                SeasidePackage seaside => seaside.AccommodationType,
                MountainPackage mountain => mountain.AccommodationType,
                _ => ""
            };
        }
        
        protected virtual string GetTransportationType(TravelPackage package)
        {
            return package switch
            {
                SeasidePackage seaside => seaside.TransportationType,
                MountainPackage mountain => mountain.TransportationType,
                ExcursionPackage excursion => excursion.TransportationType,
                _ => ""
            };
        }
        
        protected virtual string GetGuide(TravelPackage package)
        {
            return package is ExcursionPackage excursion ? excursion.Guide : "";
        }
        
        protected virtual string GetShip(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.Ship : "";
        }
        
        protected virtual string GetRoute(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.Route : "";
        }
        
        protected virtual string GetDepartureDate(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.DepartureDate.ToString("yyyy-MM-dd") : "";
        }
        
        protected virtual string GetCabinType(TravelPackage package)
        {
            return package is CruisePackage cruise ? cruise.CabinType : "";
        }
        
        protected virtual string GetActivities(TravelPackage package)
        {
            return package is MountainPackage mountain ? string.Join(",", mountain.Activities) : "";
        }
    }
}
