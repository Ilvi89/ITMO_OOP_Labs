using System;
using System.Collections.Generic;
using System.IO;
using BackupsExtra.Algo.Cut;
using BackupsExtra.Algo.GetExtreme;
using BackupsExtra.Algo.Save;
using BackupsExtra.Repo;

namespace BackupsExtra.Entity
{
    [Serializable]
    public class BackupJobExtra
    {
        private readonly ILogger _logger;

        public BackupJobExtra(
            string name,
            List<string> watchedFilePaths,
            ILogger logger,
            IRestorePointRepo restorePointRepo,
            CutType cutType,
            GetExtremeAlgo cleanAlgo)
        {
            Name = name;
            WatchedFilePaths = watchedFilePaths;
            RestorePointRepo = restorePointRepo;
            CutType = cutType;
            ExtremeAlgo = cleanAlgo;
            _logger = logger;
        }

        public CutType CutType { get; }
        public GetExtremeAlgo ExtremeAlgo { get; }
        public IRestorePointRepo RestorePointRepo { get; }

        public string Name { get; }
        public List<string> WatchedFilePaths { get; }

        public RestorePoint CreateRestorePoint(SaveAlgoType saveAlgoType)
        {
            var backups = new List<Backup>();

            foreach (string watchedFilePath in WatchedFilePaths)
            {
                backups.Add(new Backup(
                    Guid.NewGuid().ToString(),
                    new FileInfo(watchedFilePath).FullName));
            }

            var restorePoint = new RestorePoint(Guid.NewGuid().ToString(), DateTime.Now, saveAlgoType, backups);

            new CutAgoFabric(CutType, RestorePointRepo)
                .Execute(ExtremeAlgo.GetExtreme(restorePoint));
            new SaveAgoFabric(saveAlgoType, RestorePointRepo, Name).Execute(restorePoint);
            return restorePoint;
        }

        public void Recover(RestorePoint restorePoint)
        {
            throw new NotImplementedException();
        }
    }
}