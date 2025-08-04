using _Project.Services.CurrentLevelProgress;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;

namespace _Project.StaticData
{
    public interface IStaticData
    {
        void LoadStaticData();
        LevelConfig ForLevel(int levelID);
        WindowConfig ForWindow(WindowId endGame);
        GameWindowConfig ForGameWindow(GameWindowId endGame);
    }
}