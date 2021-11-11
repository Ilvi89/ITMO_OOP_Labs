using System;
using System.Collections.Generic;
using Backups.Repository;

namespace Backups.Entity
{
    public class BackupJob
    {
        private readonly string _backupName;
        private readonly IStorageRepository _storageRepository;
        private readonly List<string> _watchedFilePaths;

        public BackupJob(string backupName, IStorageRepository storageRepository, List<string> watchedFilePaths)
        {
            _storageRepository = storageRepository ?? throw new ArgumentNullException(nameof(storageRepository));
            _backupName = backupName ?? throw new ArgumentNullException(nameof(backupName));
            _watchedFilePaths = watchedFilePaths ?? new List<string>();
        }

        public void AddFile(string path)
        {
            _watchedFilePaths.Add(path);
        }

        public void RemoveFile(string path)
        {
            _watchedFilePaths.Remove(path);
        }

        public RestorePoint CreateSplitRestorePoint()
        {
            var rp = new RestorePoint(Guid.NewGuid().ToString(), DateTime.Now);
            foreach (string watchedFilePath in _watchedFilePaths)
            {
                var storage = new Storage(
                    Guid.NewGuid().ToString(),
                    rp.Id,
                    watchedFilePath);
                _storageRepository.SplitSave(storage);
            }

            return rp;
        }

        public RestorePoint CreateSingleRestorePoint()
        {
            var rp = new RestorePoint(Guid.NewGuid().ToString(), DateTime.Now);
            var storagesToSave = new List<Storage>();
            foreach (string watchedFilePath in _watchedFilePaths)
            {
                var storage = new Storage(
                    Guid.NewGuid().ToString(),
                    rp.Id,
                    watchedFilePath);
                storagesToSave.Add(storage);
            }

            _storageRepository.SingleSave(storagesToSave);

            return rp;
        }
    }
}