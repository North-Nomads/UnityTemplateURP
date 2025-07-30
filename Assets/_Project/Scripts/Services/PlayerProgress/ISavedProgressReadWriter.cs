namespace Template._Project.Scripts.Services.PersistentProgress
{
    public interface ISavedProgressReadWriter : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress playerProgress);
    }
}