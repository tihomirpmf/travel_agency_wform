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
                backupSql.AppendLine($"INSERT INTO Clients VALUES ({clientReader.GetInt32(clientReader.GetOrdinal("Id"))}, '{clientReader.GetString(clientReader.GetOrdinal("FirstName"))}', '{clientReader.GetString(clientReader.GetOrdinal("LastName"))}', '{clientReader.GetString(clientReader.GetOrdinal("PassportNumber"))}', '{clientReader.GetDateTime(clientReader.GetOrdinal("DateOfBirth")):yyyy-MM-dd}', '{clientReader.GetString(clientReader.GetOrdinal("Email"))}', '{clientReader.GetString(clientReader.GetOrdinal("PhoneNumber"))}', '{clientReader.GetDateTime(clientReader.GetOrdinal("CreatedAt")):yyyy-MM-dd HH:mm:ss}');");
            }
            clientReader.Close();
            
            return backupSql.ToString();
        }
    }
}


