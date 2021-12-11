using BackupsExtra.Algo.Cut;
using BackupsExtra.Entity;
using BackupsExtra.Exceptions;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo.Save
{
    public class SaveAgoFabric : AgoFabric
    {
        private readonly SaveAlgoType _saveAlgo;
        private string _basePath;

        public SaveAgoFabric(SaveAlgoType saveAlgo, IRestorePointRepo restorePointRepo, string basePath)
            : base(restorePointRepo)
        {
            _saveAlgo = saveAlgo;
            _basePath = basePath;
        }

        public void Execute(RestorePoint restorePoint)
        {
            switch (_saveAlgo)
            {
                case SaveAlgoType.Singl:
                    new Singl(RestorePointRepo, _basePath).Save(restorePoint);
                    break;
                case SaveAlgoType.Split:
                    new Split(RestorePointRepo, _basePath).Save(restorePoint);
                    break;
                default:
                    throw new BackupsExtraException("save type not exist");
            }
        }
    }
}