using _Project.UI.GameWindows;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using _Project.UI.Windows;

namespace _Project.UI.Services.Factory
{
    public interface IUIFactory 
    {
        void CreateUIRoot();
        WindowBase InstantiateWindow(HubWindowId hubWindowId);
        GameWindowBase InstantiateWindow(GameWindowId windowID);
    }
}