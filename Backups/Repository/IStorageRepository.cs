using System.Collections.Generic;
using Backups.Entity;

namespace Backups.Repository
{
    public interface IStorageRepository
    {
        Storage GetById(string id);
        List<Storage> GetByRestorePointId(string restorePointId);
        public Storage SplitSave(Storage storage);
        public List<Storage> SingleSave(List<Storage> storages);
    }
}