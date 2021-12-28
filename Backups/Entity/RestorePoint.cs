using System;

namespace Backups.Entity
{
    public class RestorePoint
    {
        public RestorePoint(string id, DateTime createdAt)
        {
            Id = id;
            CreatedAt = createdAt;
        }

        public string Id { get; }
        public DateTime CreatedAt { get; }
    }
}