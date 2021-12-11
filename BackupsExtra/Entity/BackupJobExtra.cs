using System;
using System.Collections.Generic;
using BackupsExtra.Algorithms;

namespace BackupsExtra.Entity
{
    public class BackupJobExtra
    {
        private readonly Algorithm _algorithm;
        private readonly ILogger _logger;

        public BackupJobExtra(
            string name,
            List<string> watchedFilePaths,
            Algorithm algorithm,
            ILogger logger,
            int maxRestorePointCount)
        {
            Name = name;
            WatchedFilePaths = watchedFilePaths;
            RestorePoints = new List<RestorePoint>();
            _logger = logger;
            _algorithm = algorithm;
        }

        public string Name { get; }
        private List<string> WatchedFilePaths { get; }
        private List<RestorePoint> RestorePoints { get; }

        public RestorePoint CreateRestorePoint(RestorePointType restorePointType)
        {
            var restorePoint = new RestorePoint(Guid.NewGuid().ToString(), DateTime.Now, restorePointType);

            return restorePoint;
        }

        public void Recover(RestorePoint restorePoint)
        {
        }
    }
}