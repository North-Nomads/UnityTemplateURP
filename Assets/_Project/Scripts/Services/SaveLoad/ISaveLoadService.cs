using Template._Project.Scripts.Services.PersistentProgress;

namespace Template._Project.Scripts.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}