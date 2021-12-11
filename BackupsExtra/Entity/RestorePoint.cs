using System;
using BackupsExtra.Algo;

namespace BackupsExtra.Entity
{
    public class RestorePoint
    {
        public RestorePoint(string id, DateTime createdAt, SaveAlgoType restorePointType)
        {
            Id = id;
            CreatedAt = createdAt;
            PointType = restorePointType;
        }

        public string Id { get; }
        public DateTime CreatedAt { get; }
        public SaveAlgoType PointType { get; }
    }
}