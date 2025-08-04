using System;
using _Project.UI.GameWindows;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Windows
{
    public class PlayerDeadWindow : GameWindowBase
    {
        [SerializeField] private Button restartButton;

        public event EventHandler PlayerReturnedToMenu = delegate { };

        private void Awake() 
            => restartButton.onClick.AddListener(GoToMenu);

        private void GoToMenu() 
            => PlayerReturnedToMenu(null, null);
    }
}