using System.Data.Common;
using travel_agency_wform.Services.Database.Adapters;

namespace travel_agency_wform.Services.Database.Factories
{
    public class DatabaseFactory
    {
        public static DbConnection CreateConnection(string connectionString)
        {
            if (IsSqliteConnection(connectionString))
            {
                var factory = new SqliteConnectionFactory(connectionString);
                return factory.CreateConnection();
            }
            else if (IsMySqlConnection(connectionString))
            {
                var factory = new MySqlConnectionFactory(connectionString);
                return factory.CreateConnection();
            }
            else
            {
                // Default to SQLite
                var factory = new SqliteConnectionFactory(connectionString);
                return factory.CreateConnection();
            }
        }
        
        public static IDatabaseAdapter CreateAdapter(string connectionString)
        {
            if (IsSqliteConnection(connectionString))
            {
                return new SqliteDatabaseAdapter(connectionString);
            }
            else if (IsMySqlConnection(connectionString))
            {
                return new MySqlDatabaseAdapter(connectionString);
            }
            else
            {
                // Default to SQLite
                return new SqliteDatabaseAdapter(connectionString);
            }
        }
        
        private static bool IsSqliteConnection(string connectionString)
        {
            return connectionString.Contains("Data Source=") || connectionString.Contains(".db");
        }
        
        private static bool IsMySqlConnection(string connectionString)
        {
            return connectionString.Contains("Server=") || connectionString.Contains("Database=");
        }
    }
}
