using Microsoft.Data.Sqlite;
using System.Data.Common;
using travel_agency_wform.Models;
using travel_agency_wform.Services.Builders;

namespace travel_agency_wform.Services.Database
{
    // Strategy Pattern: Concrete implementation for SQLite database operations
    // Purpose: Provides SQLite-specific database functionality
    public class SqliteDatabaseAdapter : BaseDatabaseAdapter
    {
        public SqliteDatabaseAdapter(string connectionString) : base(connectionString)
        {
        }
        
        protected override DbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
        
        protected override DbCommand CreateCommand(string sql, DbConnection connection)
        {
            return new SqliteCommand(sql, (SqliteConnection)connection);
        }
        
        protected override void AddParameter(DbCommand command, string name, object value)
        {
            ((SqliteCommand)command).Parameters.AddWithValue(name, value);
        }
        
        protected override string GetLastInsertIdSql()
        {
            return "SELECT last_insert_rowid()";
        }
        
        protected override string GetAutoIncrementSql()
        {
            return "INTEGER PRIMARY KEY AUTOINCREMENT";
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
            return DateTime.Parse(reader.GetString(reader.GetOrdinal(columnName)));
        }
        
        protected override string GetBackupTemplateType()
        {
            return "Sqlite";
        }
        
        protected override TravelPackage? CreatePackageFromReader(DbDataReader reader)
        {
            var type = (PackageType)reader.GetInt32(reader.GetOrdinal("Type"));
            
            switch (type)
            {
                case PackageType.Seaside:
                    return new SeasidePackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType")),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"))
                    };
                    
                case PackageType.Mountain:
                    var activities = reader.IsDBNull(reader.GetOrdinal("Activities")) ? "" : reader.GetString(reader.GetOrdinal("Activities"));
                    return new MountainPackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        AccommodationType = reader.IsDBNull(reader.GetOrdinal("AccommodationType")) ? "" : reader.GetString(reader.GetOrdinal("AccommodationType")),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType")),
                        Activities = string.IsNullOrEmpty(activities) ? new List<string>() : activities.Split(',').ToList()
                    };
                    
                case PackageType.Excursion:
                    return new ExcursionPackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType")),
                        Guide = reader.IsDBNull(reader.GetOrdinal("Guide")) ? "" : reader.GetString(reader.GetOrdinal("Guide"))
                    };
                    
                case PackageType.Cruise:
                    return new CruisePackage
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Type = type,
                        Destination = reader.GetString(reader.GetOrdinal("Destination")),
                        NumberOfDays = reader.GetInt32(reader.GetOrdinal("NumberOfDays")),
                        CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                        Ship = reader.IsDBNull(reader.GetOrdinal("Ship")) ? "" : reader.GetString(reader.GetOrdinal("Ship")),
                        Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? "" : reader.GetString(reader.GetOrdinal("Route")),
                        DepartureDate = reader.IsDBNull(reader.GetOrdinal("DepartureDate")) ? DateTime.Now : DateTime.Parse(reader.GetString(reader.GetOrdinal("DepartureDate"))),
                        CabinType = reader.IsDBNull(reader.GetOrdinal("CabinType")) ? "" : reader.GetString(reader.GetOrdinal("CabinType")),
                        TransportationType = reader.IsDBNull(reader.GetOrdinal("TransportationType")) ? "" : reader.GetString(reader.GetOrdinal("TransportationType"))
                    };
                    
                default:
                    return null;
            }
        }
    }
}
