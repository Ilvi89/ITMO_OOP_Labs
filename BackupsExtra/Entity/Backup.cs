using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Entity;

namespace BackupsExtra.Entity
{
    public class Backup
    {
        public Guid Id { get; }
        public DateTime CreationTime { get; }
        public List<RestorePoint> RestorePoints { get; }
        private StorageType StorageType { get; }
    }
}