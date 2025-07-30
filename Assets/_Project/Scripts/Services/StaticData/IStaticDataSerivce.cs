using Template._Project.Scripts.Services.UIFactory;

namespace Template._Project.Scripts.Services.StaticData
{
    public interface IStaticDataService
    {
        public void LoadConfigs();
        // public void ForMobID(int mobID);
        // public void ForSentryID(int sentryID);
        // etc
        HubWindowConfig ForHubWindow(HubWindowId windowID);
        GameWindowConfig ForGameWindow(GameWindowId windowID);
    }
}