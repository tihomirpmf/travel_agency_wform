using travel_agency_wform.Services;

namespace travel_agency_wform.Services.Database
{
    public class DatabaseFactory
    {
        public static IDatabaseConnection CreateConnection()
        {
            var config = ConfigurationManager.Instance;
            var connectionString = config.ConnectionString;
            
            if (connectionString.Contains("Data Source=") || connectionString.Contains(".db"))
            {
                return new SqliteConnectionFactory(connectionString);
            }
            else if (connectionString.Contains("Server=") || connectionString.Contains("Database="))
            {
                return new MySqlConnectionFactory(connectionString);
            }
            else
            {
                // Default to SQLite
                return new SqliteConnectionFactory(connectionString);
            }
        }
    }
}
