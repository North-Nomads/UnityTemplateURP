using System.Collections.Generic;
using _Project.Services.CurrentLevelProgress;
using _Project.UI.GameWindows;
using _Project.UI.Services.Factory;

namespace _Project.UI.Services.GameWindows
{
    public class GameWindow : IGameWindow
    {
        private readonly Dictionary<GameWindowId, GameWindowBase> _windows;
        private readonly IUIFactory _uiFactory;
        private readonly ILevelProgress _levelProgress;


        private GameWindowId _previousWindow;
        private GameWindowId _currentWindow;

        public GameWindow(IUIFactory uiFactory, ILevelProgress levelProgress)
        {
            _windows = new();
            _uiFactory = uiFactory;
            _levelProgress = levelProgress;
        }

        public void CleanUp()
        {
            _currentWindow = GameWindowId.InGameHUD;
            _previousWindow = GameWindowId.Unknown;
            _windows.Clear();
        }

        public bool HasOpenedWindows()
            => _currentWindow != GameWindowId.InGameHUD; // if hud is opened, player is busy

        public GameWindowBase GetWindow(GameWindowId windowID)
        {
            _windows.TryGetValue(windowID, out var window);
            if (window == null)
            {
                window = _uiFactory.InstantiateWindow(windowID);
                window.ConstructWindow(this, _levelProgress);
                _windows[windowID] = window;
            }
            return window;
        }

        public void Open(GameWindowId windowId)
        {
            foreach (var windowKeyValuePair in _windows)
            {
                windowKeyValuePair.Value.gameObject.SetActive(false);
                windowKeyValuePair.Value.OnClosed();
            }

            var window = GetWindow(windowId);
            _previousWindow = _currentWindow;
            _currentWindow = windowId;

            window.gameObject.SetActive(true);
            window.OnOpened();
        }

        public void ReturnToPreviousWindow()
            => Open(_previousWindow);
    }
}