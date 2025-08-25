using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace travel_agency_wform.Services.Database
{
    public class SqliteConnectionFactory : IDatabaseConnection
    {
        private readonly string _connectionString;
        
        public SqliteConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public DbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
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
