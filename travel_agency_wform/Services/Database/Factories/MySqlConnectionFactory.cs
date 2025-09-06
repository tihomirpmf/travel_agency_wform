using MySql.Data.MySqlClient;
using System.Data.Common;

namespace travel_agency_wform.Services.Database.Factories
{
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
        
    }
}
