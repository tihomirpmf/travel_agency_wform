using System.Data.Common;

namespace travel_agency_wform.Services.Database
{
    public interface IDatabaseConnection
    {
        DbConnection CreateConnection();
        string GetConnectionString();
    }
}
