using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace travel_agency_wform.Services.Database
{
    // Strategy Pattern: Concrete implementation for SQLite connection strategy
    // Purpose: Encapsulates SQLite-specific connection creation and management
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
        
    }
}
