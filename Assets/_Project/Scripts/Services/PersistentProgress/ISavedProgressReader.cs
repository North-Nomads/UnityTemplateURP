using _Project.Data;

namespace _Project.Services.PlayerProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(CurrentPlayerProgress progress);
    }
}