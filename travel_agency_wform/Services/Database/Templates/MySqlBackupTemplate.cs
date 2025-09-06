using MySql.Data.MySqlClient;

namespace travel_agency_wform.Services.Database.Templates
{
    public class MySqlBackupTemplate : BackupTemplate
    {
        private readonly string _connectionString;
        
        public MySqlBackupTemplate(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        protected override string GetFileExtension() => ".sql";
        
        protected override async Task<bool> PerformProviderBackupAsync(string backupFilePath)
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                
                var sql = await GenerateBackupSqlAsync(connection);
                await File.WriteAllTextAsync(backupFilePath, sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        private async Task<string> GenerateBackupSqlAsync(MySqlConnection connection)
        {
            var backupSql = new System.Text.StringBuilder();
            backupSql.AppendLine("-- Travel Agency Database Backup");
            backupSql.AppendLine($"-- Generated on: {DateTime.Now}");
            backupSql.AppendLine();
            
            // Clients
            backupSql.AppendLine("-- Clients");
            var clientSql = "SELECT * FROM Clients";
            using var clientCommand = new MySqlCommand(clientSql, connection);
            using var clientReader = (MySqlDataReader)await clientCommand.ExecuteReaderAsync();
            while (await clientReader.ReadAsync())
            {
                var firstName = clientReader.GetString(clientReader.GetOrdinal("FirstName")).Replace("'", "''");
                var lastName = clientReader.GetString(clientReader.GetOrdinal("LastName")).Replace("'", "''");
                var passportNumber = clientReader.GetString(clientReader.GetOrdinal("PassportNumber")).Replace("'", "''");
                var email = clientReader.GetString(clientReader.GetOrdinal("Email")).Replace("'", "''");
                var phoneNumber = clientReader.GetString(clientReader.GetOrdinal("PhoneNumber")).Replace("'", "''");
                
                backupSql.AppendLine($"INSERT INTO Clients VALUES ({clientReader.GetInt32(clientReader.GetOrdinal("Id"))}, '{firstName}', '{lastName}', '{passportNumber}', '{clientReader.GetDateTime(clientReader.GetOrdinal("DateOfBirth")):yyyy-MM-dd}', '{email}', '{phoneNumber}', '{clientReader.GetDateTime(clientReader.GetOrdinal("CreatedAt")):yyyy-MM-dd HH:mm:ss}');");
            }
            clientReader.Close();
            
            // TravelPackages
            backupSql.AppendLine();
            backupSql.AppendLine("-- TravelPackages");
            var packageSql = "SELECT * FROM TravelPackages";
            using var packageCommand = new MySqlCommand(packageSql, connection);
            using var packageReader = (MySqlDataReader)await packageCommand.ExecuteReaderAsync();
            while (await packageReader.ReadAsync())
            {
                var name = packageReader.GetString(packageReader.GetOrdinal("Name")).Replace("'", "''");
                var destination = packageReader.GetString(packageReader.GetOrdinal("Destination")).Replace("'", "''");
                var accommodationType = packageReader.IsDBNull(packageReader.GetOrdinal("AccommodationType")) ? "NULL" : $"'{packageReader.GetString(packageReader.GetOrdinal("AccommodationType")).Replace("'", "''")}'";
                var transportationType = packageReader.IsDBNull(packageReader.GetOrdinal("TransportationType")) ? "NULL" : $"'{packageReader.GetString(packageReader.GetOrdinal("TransportationType")).Replace("'", "''")}'";
                var guide = packageReader.IsDBNull(packageReader.GetOrdinal("Guide")) ? "NULL" : $"'{packageReader.GetString(packageReader.GetOrdinal("Guide")).Replace("'", "''")}'";
                var ship = packageReader.IsDBNull(packageReader.GetOrdinal("Ship")) ? "NULL" : $"'{packageReader.GetString(packageReader.GetOrdinal("Ship")).Replace("'", "''")}'";
                var route = packageReader.IsDBNull(packageReader.GetOrdinal("Route")) ? "NULL" : $"'{packageReader.GetString(packageReader.GetOrdinal("Route")).Replace("'", "''")}'";
                var cabinType = packageReader.IsDBNull(packageReader.GetOrdinal("CabinType")) ? "NULL" : $"'{packageReader.GetString(packageReader.GetOrdinal("CabinType")).Replace("'", "''")}'";
                var activities = packageReader.IsDBNull(packageReader.GetOrdinal("Activities")) ? "NULL" : $"'{packageReader.GetString(packageReader.GetOrdinal("Activities")).Replace("'", "''")}'";
                
                backupSql.AppendLine($"INSERT INTO TravelPackages VALUES ({packageReader.GetInt32(packageReader.GetOrdinal("Id"))}, '{name}', {packageReader.GetDecimal(packageReader.GetOrdinal("Price"))}, {packageReader.GetInt32(packageReader.GetOrdinal("Type"))}, '{destination}', {packageReader.GetInt32(packageReader.GetOrdinal("NumberOfDays"))}, '{packageReader.GetDateTime(packageReader.GetOrdinal("CreatedAt")):yyyy-MM-dd HH:mm:ss}', {accommodationType}, {transportationType}, {guide}, {ship}, {route}, {cabinType}, {activities});");
            }
            packageReader.Close();
            
            // Reservations
            backupSql.AppendLine();
            backupSql.AppendLine("-- Reservations");
            var reservationSql = "SELECT * FROM Reservations";
            using var reservationCommand = new MySqlCommand(reservationSql, connection);
            using var reservationReader = (MySqlDataReader)await reservationCommand.ExecuteReaderAsync();
            while (await reservationReader.ReadAsync())
            {
                backupSql.AppendLine($"INSERT INTO Reservations VALUES ({reservationReader.GetInt32(reservationReader.GetOrdinal("Id"))}, {reservationReader.GetInt32(reservationReader.GetOrdinal("ClientId"))}, {reservationReader.GetInt32(reservationReader.GetOrdinal("PackageId"))}, {reservationReader.GetInt32(reservationReader.GetOrdinal("NumberOfTravelers"))}, {reservationReader.GetDecimal(reservationReader.GetOrdinal("TotalPrice"))}, {reservationReader.GetInt32(reservationReader.GetOrdinal("Status"))});");
            }
            reservationReader.Close();
            
            return backupSql.ToString();
        }
    }
}


