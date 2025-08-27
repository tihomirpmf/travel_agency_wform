using System.Text;

namespace travel_agency_wform.Services.Database.Templates
{
    // Template Method Pattern: Defines backup algorithm skeleton
    // Purpose: Provides consistent backup process structure with customizable steps
    public abstract class BackupTemplate
    {
        public async Task<bool> RunAsync()
        {
            try
            {
                var backupDir = EnsureBackupDirectory();
                var backupFile = GetBackupFilePath(backupDir);
                var ok = await PerformProviderBackupAsync(backupFile);
                return ok;
            }
            catch
            {
                return false;
            }
        }
        
        protected virtual string EnsureBackupDirectory()
        {
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backups");
            Directory.CreateDirectory(dir);
            return dir;
        }
        
        protected virtual string GetBackupFilePath(string dir)
        {
            var name = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}{GetFileExtension()}";
            return Path.Combine(dir, name);
        }
        
        protected abstract string GetFileExtension();
        protected abstract Task<bool> PerformProviderBackupAsync(string backupFilePath);
    }
}


