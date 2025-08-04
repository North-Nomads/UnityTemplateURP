using _Project.Data;

namespace _Project.Infrastructure.SaveLoad
{
    public interface ISaveLoad 
    {
        void SaveProgress();
        CurrentPlayerProgress LoadProgress();
    }
}