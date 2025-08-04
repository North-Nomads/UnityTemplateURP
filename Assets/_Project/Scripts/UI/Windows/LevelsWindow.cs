using System;
using System.Collections.Generic;
using _Project.Services.Factory;
using _Project.Infrastructure.SaveLoad;
using _Project.Services;
using _Project.Services.PlayerProgress;
using _Project.UI.Services.Factory;
using _Project.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Windows
{
    public class LevelsWindow : WindowBase
    {
        [SerializeField] private Transform buttonsParent;
        [SerializeField] private Button exitButton;

        public event EventHandler<int> LevelLaunched = delegate { };

        private void Awake()
        {
            exitButton.onClick.AddListener(() => WindowService.Open(WindowId.Hub));
        }

        public override void ConstructWindow(IPersistentProgress progress, WindowId windowId, IWindowService windowService,
            ISaveLoad saveLoad, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            base.ConstructWindow(progress, windowId, windowService, saveLoad, gameFactory, uiFactory);
            List<LevelSelectButton> buttons = UIFactory.InstantiateLevelButtons(Constants.TotalLevels, buttonsParent);
            foreach (LevelSelectButton button in buttons) 
                button.LevelButtonPressed += (_, levelIndex) => LevelLaunched(this, levelIndex);
        }
    }
    
}