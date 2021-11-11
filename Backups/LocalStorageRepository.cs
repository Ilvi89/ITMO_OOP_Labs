using System.Collections.Generic;
using System.Linq;
using Backups.Entity;
using Backups.Repository;

namespace Isu.Tests
{
    public class LocalStorageRepository : IStorageRepository
    {
        // pointDir/storageFiles|storageArchive[files]
        private readonly Dictionary<string, List<Storage>> _localFiles = new ();

        public int CountOfStorages => _localFiles.Values.SelectMany(list => list).ToList().Count;

        public Storage GetById(string id)
        {
            Storage storage = null;
            foreach (List<Storage> storages in _localFiles.Values) storage = storages.Find(s => s.Id == id);
            return storage;
        }

        public List<Storage> GetByRestorePointId(string restorePointId)
        {
            return _localFiles[restorePointId];
        }

        public Storage SplitSave(Storage storage)
        {
            if (!_localFiles.ContainsKey(storage.RestorePointId))
                _localFiles.Add(storage.RestorePointId, new List<Storage>());
            _localFiles[storage.RestorePointId].Add(storage);
            return storage;
        }

        public List<Storage> SingleSave(List<Storage> storages)
        {
            _localFiles.Add(storages[0].RestorePointId, new List<Storage>());
            _localFiles[storages[0].RestorePointId] = storages;
            return storages;
        }
    }
}