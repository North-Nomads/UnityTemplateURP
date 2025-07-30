using Template._Project.Scripts.Services.StaticData;

namespace Template._Project.Scripts.Services.UIFactory
{
    public interface IUIFactory
    {
        HubWindowBase InstantiateWindow(HubWindowId hubWindowId);
        GameWindowBase InstantiateWindow(GameWindowId windowID);
    }
}