using MySql.Data.MySqlClient;
using System.Data.Common;

namespace travel_agency_wform.Services.Database
{
    // Strategy Pattern: Concrete implementation for MySQL connection strategy
    // Purpose: Encapsulates MySQL-specific connection creation and management
    public class MySqlConnectionFactory : IDatabaseConnection
    {
        private readonly string _connectionString;
        
        public MySqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public DbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        
        public string GetConnectionString()
        {
            return _connectionString;
        }
        
        public bool TestConnection()
        {
            try
            {
                using var connection = CreateConnection();
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
