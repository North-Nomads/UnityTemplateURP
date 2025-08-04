using System.Collections.Generic;
using System.Linq;
using _Project.Services.CurrentLevelProgress;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using UnityEngine;

namespace _Project.StaticData
{
    public class ScriptableStaticData : IStaticData
    {
        private Dictionary<GameWindowId, GameWindowConfig> _gameWindowConfigs;
        private Dictionary<HubWindowId, HubWindowConfig> _windowConfigs;
        private Dictionary<int, LevelConfig> _levels;
        private Texture2D _tileAtlas;
        private LineRenderer _wirePrefab;

        public void LoadLevels()
            => _levels = Resources.LoadAll<LevelConfig>("Configs/Levels").ToDictionary(x => x.LevelID, x => x);

        public void LoadStaticData()
        {
            LoadWindows();
            LoadGameWindows();
        }
        
        public LevelConfig ForLevel(int levelID)
            => _levels.GetValueOrDefault(levelID);

        public HubWindowConfig ForWindow(HubWindowId hubWindowId)
            => _windowConfigs.GetValueOrDefault(hubWindowId);

        public GameWindowConfig ForGameWindow(GameWindowId windowId)
            => _gameWindowConfigs.GetValueOrDefault(windowId);
        
        private void LoadGameWindows()
            => _gameWindowConfigs = Resources.Load<GameWindowStaticData>("UI/GameWindows").Configs
                .ToDictionary(x => x.WindowId, x => x);

        private void LoadWindows()
            => _windowConfigs = Resources.Load<WindowStaticData>("UI/Windows").Configs
                .ToDictionary(x => x.hubWindowId, x => x);
    }
}