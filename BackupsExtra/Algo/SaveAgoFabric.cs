using BackupsExtra.Entity;
using BackupsExtra.Exceptions;
using BackupsExtra.Repo;

namespace BackupsExtra.Algo
{
    public class SaveAgoFabric
    {
        private SaveAlgoType _saveAlgo;
        private IRestorePointRepo _restorePointRepo;

        public SaveAgoFabric(SaveAlgoType saveAlgo, IRestorePointRepo restorePointRepo)
        {
            _saveAlgo = saveAlgo;
            _restorePointRepo = restorePointRepo;
        }

        public void ExecuteSaveAlgo(RestorePoint restorePoint)
        {
            switch (_saveAlgo)
            {
                case SaveAlgoType.Singl:
                    new SingleSaveAlgo(_restorePointRepo).Save(restorePoint);
                    break;
                case SaveAlgoType.Split:
                    new SplitSaveAlgo(_restorePointRepo).Save(restorePoint);
                    break;
                default:
                    throw new BackupsExtraException("save type not exist");
            }
        }
    }
}