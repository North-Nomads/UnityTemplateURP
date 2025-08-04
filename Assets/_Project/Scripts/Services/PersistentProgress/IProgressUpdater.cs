using _Project.Data;

namespace _Project.Services.PlayerProgress
{
    public interface IProgressUpdater : ISavedProgressReader
    {
        void UpdateProgress(Data.CurrentPlayerProgress progress);
    }
}