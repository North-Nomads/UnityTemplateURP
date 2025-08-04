using System;
using _Project.Infrastructure.InGameTime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace _Project.UI.GameWindows
{
    public class InGamePauseMenu : GameWindowBase
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartButton; 
        private IInGameTimeService _timeService;
        private PlayerInput _inputActions;

        public event EventHandler RestartButtonPressed = delegate { };
        public event EventHandler ReturnToMenuButtonPressed = delegate { };
        

        private void Awake()
        {
            // these two buttons do the same
            continueButton.onClick.AddListener(ResumeGame);
            
            restartButton.onClick.AddListener(() => RestartButtonPressed(this, EventArgs.Empty));
            exitButton.onClick.AddListener(() => ReturnToMenuButtonPressed(this, EventArgs.Empty));
        }

        public override void OnOpened()
        {
            base.OnOpened();
            _timeService.EnablePause();
        }

        public override void OnClosed()
        {
            base.OnClosed();
            _timeService.RestoreTimePassage();
        }

        private void ResumeGame()
        {
            GameWindow.ReturnToPreviousWindow();
        }
    }
}