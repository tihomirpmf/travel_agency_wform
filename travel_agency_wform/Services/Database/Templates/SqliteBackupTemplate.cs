namespace travel_agency_wform.Services.Database.Templates
{
    public class SqliteBackupTemplate : BackupTemplate
    {
        private readonly string _connectionString;
        
        public SqliteBackupTemplate(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        protected override string GetFileExtension() => ".db";
        
        protected override Task<bool> PerformProviderBackupAsync(string backupFilePath)
        {
            try
            {
                var sourcePath = _connectionString.Replace("Data Source=", "");
                File.Copy(sourcePath, backupFilePath);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}


