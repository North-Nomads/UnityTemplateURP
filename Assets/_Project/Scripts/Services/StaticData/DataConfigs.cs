using System;
using Template._Project.Scripts.Services.UIFactory;

namespace Template._Project.Scripts.Services.StaticData
{
    [Serializable]
    public class HubWindowConfig
    {
        public HubWindowId WindowId;
        public HubWindowBase Prefab;
    }

    [Serializable]
    public class GameWindowConfig
    {
        public GameWindowId WindowId;
        public GameWindowBase Prefab;
    }

    // Mob configs, Level configs, etc
}