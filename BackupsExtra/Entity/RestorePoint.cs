using System;

namespace BackupsExtra.Entity
{
    public abstract class RestorePoint
    {
        public DateTime CreationTime { get; }
        public abstract long Size { get; }
        public long Length { get; }
        public string FullPath { get; }
        public string Name { get; }
        public string DirectoryName { get; }
        public string OriginalFilePath { get; }
    }
}