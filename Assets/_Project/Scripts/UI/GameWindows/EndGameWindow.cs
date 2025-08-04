using System;
using _Project.UI.GameWindows;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Windows
{
    public class EndGameWindow : GameWindowBase
    {
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button nextButton;

        public event EventHandler RestartLevelButtonPressed = delegate { };
        public event EventHandler ReturnToHubButtonPressed = delegate { };
        public event EventHandler LaunchNextLevelButtonPressed = delegate { };
        
        protected override void OnStart()
        {
            base.OnStart();
            restartButton.onClick.AddListener(() => RestartLevelButtonPressed(this, null));
            exitButton.onClick.AddListener(() => ReturnToHubButtonPressed(this, null));
            nextButton.onClick.AddListener(() => LaunchNextLevelButtonPressed(this, null));
        }

        protected override void Initialize()
        {
            base.Initialize();
            header.text = LevelProgress.IsLevelSuccessfullyFinished ? "You Win!" : "You Lose!"; 
        }
    }
}