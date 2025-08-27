using MySql.Data.MySqlClient;
using System.Data.Common;
using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders;

namespace travel_agency_wform.Services.Database
{
    // Strategy Pattern: Concrete implementation for MySQL database operations
    // Purpose: Provides MySQL-specific database functionality
    public class MySqlDatabaseAdapter : BaseDatabaseAdapter
    {
        public MySqlDatabaseAdapter(string connectionString) : base(connectionString)
        {
        }
        
        protected override DbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        
        protected override DbCommand CreateCommand(string sql, DbConnection connection)
        {
            return new MySqlCommand(sql, (MySqlConnection)connection);
        }
        
        protected override void AddParameter(DbCommand command, string name, object value)
        {
            ((MySqlCommand)command).Parameters.AddWithValue(name, value);
        }
        
        protected override string GetLastInsertIdSql()
        {
            return "SELECT LAST_INSERT_ID()";
        }
        
        protected override string GetAutoIncrementSql()
        {
            return "INT AUTO_INCREMENT PRIMARY KEY";
        }
        
        protected override string GetDateTimeFormat()
        {
            return "yyyy-MM-dd HH:mm:ss";
        }
        
        protected override DateTime ParseDateTime(string value)
        {
            return DateTime.Parse(value);
        }
        
        protected override DateTime GetDateTime(DbDataReader reader, string columnName)
        {
            return reader.GetDateTime(reader.GetOrdinal(columnName));
        }
        
        protected override string GetBackupTemplateType()
        {
            return "MySql";
        }
        
        protected override TravelPackage? CreatePackageFromReader(DbDataReader reader)
        {
            var type = (PackageType)reader.GetInt32(reader.GetOrdinal("Type"));
            TravelPackage? package = type switch
            {
                PackageType.Seaside => new SeasidePackage(),
                PackageType.Mountain => new MountainPackage(),
                PackageType.Excursion => new ExcursionPackage(),
                PackageType.Cruise => new CruisePackage(),
                _ => null
            };
            
            if (package == null) return null;
            
            package.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            package.Name = reader.GetString(reader.GetOrdinal("Name"));
            package.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
            package.Destination = reader.GetString(reader.GetOrdinal("Destination"));
            package.NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays"));
            package.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));
            
            // Set type-specific properties
            switch (package)
            {
                case SeasidePackage seaside:
                    seaside.AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType"));
                    seaside.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    break;
                case MountainPackage mountain:
                    mountain.AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType"));
                    mountain.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    mountain.Activities = reader.IsDBNull(reader.GetOrdinal("Activities")) ? new List<string>() : reader.GetString(reader.GetOrdinal("Activities")).Split(',').ToList();
                    break;
                case ExcursionPackage excursion:
                    excursion.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    excursion.Guide = reader.IsDBNull(reader.GetOrdinal("Guide")) ? "" : reader.GetString(reader.GetOrdinal("Guide"));
                    break;
                case CruisePackage cruise:
                    cruise.Ship = reader.IsDBNull(reader.GetOrdinal("Ship")) ? "" : reader.GetString(reader.GetOrdinal("Ship"));
                    cruise.Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? "" : reader.GetString(reader.GetOrdinal("Route"));
                    cruise.DepartureDate = reader.IsDBNull(reader.GetOrdinal("DepartureDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DepartureDate"));
                    cruise.CabinType = reader.IsDBNull(reader.GetOrdinal("CabinType")) ? "" : reader.GetString(reader.GetOrdinal("CabinType"));
                    cruise.TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"));
                    break;
            }
            
            return package;
        }
    }
}
