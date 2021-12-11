using System;

namespace BackupsExtra.Entity
{
    public class RestorePoint
    {
        public RestorePoint(string id, DateTime createdAt, RestorePointType restorePointType)
        {
            Id = id;
            CreatedAt = createdAt;
            PointType = restorePointType;
        }

        public string Id { get; }
        public DateTime CreatedAt { get; }
        public RestorePointType PointType { get; }
    }
}