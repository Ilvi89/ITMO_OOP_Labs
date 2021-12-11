using BackupsExtra.Entity;
using BackupsExtra.Exceptions;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Cut
{
    public class CutAgoFabric : AgoFabric
    {
        private readonly CutType _cutType;

        public CutAgoFabric(CutType cutType, IRestorePointRepo restorePointRepo)
            : base(restorePointRepo)
        {
            _cutType = cutType;
        }

        public RestorePoint Execute(RestorePoint restorePoint)
        {
            switch (_cutType)
            {
                case CutType.Delete:
                    return new Delete(RestorePointRepo).UpTo(restorePoint);
                case CutType.Merge:
                    return new Merge(RestorePointRepo).UpTo(restorePoint);
                default:
                    throw new BackupsExtraException("cut type not exist");
            }
        }
    }
}