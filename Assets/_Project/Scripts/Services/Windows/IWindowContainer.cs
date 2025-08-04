using _Project.UI.Windows;

namespace _Project.UI.Services.Windows
{
    public interface IWindowContainer
    {
        void CleanUp();
        void Open(HubWindowId hubWindowId, bool closePopup=false);
        WindowBase GetWindow(HubWindowId hubWindowId);
        void ReturnToPreviousWindow();
    }
}