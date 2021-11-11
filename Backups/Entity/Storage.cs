namespace Backups.Entity
{
    public class Storage
    {
        public Storage(string id, string restorePointId, string originalFilePath)
        {
            Id = id;
            RestorePointId = restorePointId;
            OriginalFilePath = originalFilePath;
        }

        public string Id { get; }
        public string OriginalFilePath { get; }
        public string RestorePointId { get; }
    }
}