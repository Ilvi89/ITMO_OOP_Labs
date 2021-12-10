using System.Collections.Generic;
using System.IO;

namespace BackupsExtra.Entity
{
    public class BackupJobExtra
    {
        private readonly ILogger _logger;

        public BackupJobExtra(
            StorageType storageType, string commonFolder, List<string> fileList, Algorithm algorithm, ILogger logger)
        {
            _logger = logger;
            _logger.Info($"new backup job created");
        }

        public List<Backup> Backups { get; }
        public Algorithm Algorithm { get; }
        public StorageType StorageType { get; }
    }
}