using System;
using System.Collections.Generic;
using BackupsExtra.Algo.Save;

namespace BackupsExtra.Entity
{
    [Serializable]
    public class RestorePoint
    {
        public RestorePoint(string id, DateTime createdAt, SaveAlgoType restorePointType, List<Backup> backups)
        {
            Id = id;
            CreatedAt = createdAt;
            PointType = restorePointType;
            Backups = backups;
        }

        public string Id { get; }
        public DateTime CreatedAt { get; }
        public SaveAlgoType PointType { get; }
        public List<Backup> Backups { get; }
    }
}