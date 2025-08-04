using _Project.UI.GameWindows;
using _Project.UI.Services.GameWindows;

namespace _Project.UI.Services.GameWindows
{
    public interface IGameWindow
    {
        void CleanUp();
        bool HasOpenedWindows();
        GameWindowBase GetWindow(GameWindowId endGame);
        void Open(GameWindowId windowId);
        void ReturnToPreviousWindow();
    }
}