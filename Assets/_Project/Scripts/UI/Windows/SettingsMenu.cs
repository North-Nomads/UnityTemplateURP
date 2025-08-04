using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Windows
{
	public class SettingsMenu : WindowBase
	{
        [SerializeField] private Toggle muteToggle;
        [SerializeField] private Button backButton;

        public event EventHandler<bool> MuteToggled;

        private void Awake()
        {
            muteToggle.onValueChanged.AddListener(ToggleMute);
            backButton.onClick.AddListener(() => WindowService.ReturnToPreviousWindow());
        }

        public void ToggleMute(bool value) =>
            MuteToggled?.Invoke(this, !value);
    }
}