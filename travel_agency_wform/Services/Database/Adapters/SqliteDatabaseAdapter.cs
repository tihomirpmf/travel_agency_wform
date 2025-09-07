using Microsoft.Data.Sqlite;
using System.Data.Common;
using travel_agency_wform.Services.Database.Factories;

namespace travel_agency_wform.Services.Database.Adapters
{
    public class SqliteDatabaseAdapter : BaseDatabaseAdapter
    {
        public SqliteDatabaseAdapter(string connectionString) : base(new SqliteConnectionFactory(connectionString))
        {
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
        
    }
}
