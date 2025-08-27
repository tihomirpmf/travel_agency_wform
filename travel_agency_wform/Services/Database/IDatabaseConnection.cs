using System.Data.Common;

namespace travel_agency_wform.Services.Database
{
    // Strategy Pattern: Interface for database connection strategies
    // Purpose: Provides consistent connection interface for different database providers
    public interface IDatabaseConnection
    {
        DbConnection CreateConnection();
        string GetConnectionString();
        bool TestConnection();
    }
}
