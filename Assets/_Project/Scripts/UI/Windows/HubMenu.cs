using System;
using _Project.Services.Factory;
using _Project.Infrastructure.SaveLoad;
using _Project.Services.PlayerProgress;
using _Project.UI.Services.Factory;
using _Project.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace _Project.UI.Windows
{
    public class HubMenu : WindowBase
    {
        [SerializeField] private TextMeshProUGUI startGameButtonText;
        [SerializeField] private Button startGame;
        [SerializeField] private Button allLevels;
        [SerializeField] private Button exit;

        public event EventHandler PlayerLaunchedGame = delegate { };

        private void Awake()
        {
            startGame.onClick.AddListener(LaunchGame);
            allLevels.onClick.AddListener(DisplayAllLevelsWindow);
            exit.onClick.AddListener(CloseGame);
        }

        public override void ConstructWindow(IPersistentProgress progress, HubWindowId hubWindowId, IWindowContainer windowContainer,
            ISaveLoad saveLoad, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            base.ConstructWindow(progress, hubWindowId, windowContainer, saveLoad, gameFactory, uiFactory);
            if (!PersistentProgress.Progress.HasFinishedTutorial)
                startGameButtonText.text = "START TUTORIAL";
        }

        private void DisplayAllLevelsWindow() 
            => WindowContainer.Open(HubWindowId.Levels);

        private void CloseGame() 
            => Application.Quit();

        private void LaunchGame() 
            => PlayerLaunchedGame(null, null);
    }
}