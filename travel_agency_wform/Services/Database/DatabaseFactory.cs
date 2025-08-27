using travel_agency_wform.Services;

namespace travel_agency_wform.Services.Database
{
    public interface IDatabaseProviderFactory
    {
        IDatabaseConnection CreateConnection(string connectionString);
        IDatabaseAdapter CreateAdapter(string connectionString);
    }

    public class SqliteProviderFactory : IDatabaseProviderFactory
    {
        public IDatabaseConnection CreateConnection(string connectionString) => new SqliteConnectionFactory(connectionString);
        public IDatabaseAdapter CreateAdapter(string connectionString) => new SqliteDatabaseAdapter(connectionString);
    }

    public class MySqlProviderFactory : IDatabaseProviderFactory
    {
        public IDatabaseConnection CreateConnection(string connectionString) => new MySqlConnectionFactory(connectionString);
        public IDatabaseAdapter CreateAdapter(string connectionString) => new MySqlDatabaseAdapter(connectionString);
    }

    public class DatabaseFactory
    {
        public static IDatabaseProviderFactory CreateProvider()
        {
            var config = ConfigurationManager.Instance;
            var connectionString = config.ConnectionString;
            
            if (connectionString.Contains("Data Source=") || connectionString.Contains(".db"))
            {
                return new SqliteProviderFactory();
            }
            else if (connectionString.Contains("Server=") || connectionString.Contains("Database="))
            {
                return new MySqlProviderFactory();
            }
            else
            {
                // Default to SQLite
                return new SqliteProviderFactory();
            }
        }
    }
}
