using MySql.Data.MySqlClient;
using System.Data.Common;
using travel_agency_wform.Services.Database.Factories;

namespace travel_agency_wform.Services.Database.Adapters
{
    public class MySqlDatabaseAdapter : BaseDatabaseAdapter
    {
        public MySqlDatabaseAdapter(string connectionString) : base(new MySqlConnectionFactory(connectionString))
        {
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
        
    }
}
