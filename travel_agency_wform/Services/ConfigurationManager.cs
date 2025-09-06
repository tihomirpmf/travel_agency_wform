using System.Text;

namespace travel_agency_wform.Services
{
    public sealed class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> _instance = 
            new Lazy<ConfigurationManager>(() => new ConfigurationManager());
        
        public static ConfigurationManager Instance => _instance.Value;
        
        public string AgencyName { get; private set; } = string.Empty;
        public string ConnectionString { get; private set; } = string.Empty;
        
        private ConfigurationManager()
        {
            LoadConfiguration();
        }
        
        private void LoadConfiguration()
        {
            try
            {
                var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
                
                if (!File.Exists(configPath))
                {
                    // Create default config if it doesn't exist
                    CreateDefaultConfig(configPath);
                }
                
                var lines = File.ReadAllLines(configPath, Encoding.UTF8);
                
                if (lines.Length >= 2)
                {
                    AgencyName = lines[0].Trim();
                    ConnectionString = lines[1].Trim();
                }
                else
                {
                    throw new InvalidOperationException("Invalid configuration file format. Expected 2 lines: agency name and connection string.");
                }
                
                // Validate connection string
                if (string.IsNullOrWhiteSpace(ConnectionString))
                {
                    throw new InvalidOperationException("Connection string cannot be empty.");
                }
            }
            catch (Exception ex)
            {
                // Log the error and create a fallback configuration
                System.Diagnostics.Debug.WriteLine($"Configuration error: {ex.Message}");
                CreateFallbackConfiguration();
            }
        }
        
        private void CreateFallbackConfiguration()
        {
            AgencyName = "Travel Agency";
            ConnectionString = "Data Source=travel_agency.db";
        }
        
        private void CreateDefaultConfig(string configPath)
        {
            var defaultConfig = new[]
            {
                "Travel Agency",
                "Data Source=travel_agency.db"
            };
            
            File.WriteAllLines(configPath, defaultConfig, Encoding.UTF8);
        }
        
    }
}
