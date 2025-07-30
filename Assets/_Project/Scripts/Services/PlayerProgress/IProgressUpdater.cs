namespace Template._Project.Scripts.Services.PersistentProgress
{
    public interface IProgressUpdater : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}