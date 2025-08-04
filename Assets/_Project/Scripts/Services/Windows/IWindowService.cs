using _Project.UI.Windows;

namespace _Project.UI.Services.Windows
{
    public interface IWindowService
    {
        void CleanUp();
        void Open(WindowId windowID, bool closePopup=false);
        WindowBase GetWindow(WindowId windowID);
        void ReturnToPreviousWindow();
    }
}