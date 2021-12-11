using System;
using System.Collections.Generic;
using BackupsExtra.Algo;
using BackupsExtra.Repo;

namespace BackupsExtra.Entity
{
    public class BackupJobExtra
    {
        private readonly ILogger _logger;
        private readonly IRestorePointRepo _restorePointRepo;

        public BackupJobExtra(
            string name,
            List<string> watchedFilePaths,
            ILogger logger,
            IRestorePointRepo restorePointRepo)
        {
            Name = name;
            WatchedFilePaths = watchedFilePaths;
            RestorePoints = new List<RestorePoint>();
            _logger = logger;
            _restorePointRepo = restorePointRepo;
        }

        public string Name { get; }
        private List<string> WatchedFilePaths { get; }
        private List<RestorePoint> RestorePoints { get; }

        public RestorePoint CreateRestorePoint(SaveAlgoType saveAlgoType, CutType cutType)
        {
            var restorePoint = new RestorePoint(Guid.NewGuid().ToString(), DateTime.Now, saveAlgoType);
            _restorePointRepo.DeleteUpTo(GetExtremeRestorePoint());
            new SaveAgoFabric(saveAlgoType, _restorePointRepo).ExecuteSaveAlgo(restorePoint);
            return restorePoint;
        }

        public void Recover(RestorePoint restorePoint)
        {
            throw new NotImplementedException();
        }

        private RestorePoint GetExtremeRestorePoint()
        {
            throw new NotImplementedException();
        }
    }
}