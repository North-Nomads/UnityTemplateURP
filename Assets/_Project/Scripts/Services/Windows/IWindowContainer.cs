using _Project.UI.Windows;

namespace _Project.UI.Services.Windows
{
    public interface IWindowContainer
    {
        void CleanUp();
        void Open(FullScreenWindowId fullScreenWindowId, bool closePopup=false);
        WindowBase GetWindow(FullScreenWindowId fullScreenWindowId);
        void ReturnToPreviousWindow();
    }
}