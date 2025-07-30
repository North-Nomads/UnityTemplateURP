using System.Collections.Generic;
using System.Linq;
using Template._Project.Scripts.Data;
using Template._Project.Scripts.Services.UIFactory;
using Template._Project.Scripts.UI.StaticData;
using UnityEngine;

namespace Template._Project.Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<GameWindowId, GameWindowConfig> _gameWindowConfigs;
        private Dictionary<HubWindowId, HubWindowConfig> _hubWindowConfigs;

        public StaticDataService()
        {
            LoadConfigs();
        }
        
        public void LoadConfigs()
        {
            _hubWindowConfigs = Resources.Load<HubWindowStaticData>(AssetPath.WindowConfigsFolder + "/HubWindowStaticData").Configs
                .ToDictionary(x => x.WindowId, x => x);
            _gameWindowConfigs = Resources.Load<GameWindowStaticData>(AssetPath.WindowConfigsFolder + "/GameWindowStaticData").Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public HubWindowConfig ForHubWindow(HubWindowId windowID) 
            => _hubWindowConfigs[windowID];

        public GameWindowConfig ForGameWindow(GameWindowId windowID)
            => _gameWindowConfigs[windowID];
    }
}