using System;
using System.Collections.Generic;
using _Project.Services.Factory;
using _Project.Infrastructure.SaveLoad;
using _Project.Services.PlayerProgress;
using _Project.UI.Services.Factory;
using _Project.UI.Windows;

namespace _Project.UI.Services.Windows
{
    public class WindowService : IWindowService
    {
        private WindowId _previousWindow;
        private WindowId _currentWindow;
        private PopupWindowId _currentPopup;
        private readonly Dictionary<WindowId, WindowBase> _windows;

        private readonly IUIFactory _uiFactory;
        private readonly IPersistentProgress _progress;
        private readonly ISaveLoad _saveLoad;
        private readonly IGameFactory _gameFactory;

        public WindowService(IUIFactory uiFactory, IPersistentProgress progress,
            ISaveLoad saveLoad, IGameFactory gameFactory)
        {
            _uiFactory = uiFactory;
            _progress = progress;
            _saveLoad = saveLoad;
            _windows = new Dictionary<WindowId, WindowBase>();
            _gameFactory = gameFactory;
        }

        public void CleanUp()
        {
            _currentWindow = WindowId.Hub;
            _previousWindow = WindowId.Unknown;
            _windows.Clear();
        }

        public WindowBase GetWindow(WindowId windowID)
        {
            _windows.TryGetValue(windowID, out var window);
            if (window == null)
            {
                window = _uiFactory.InstantiateWindow(windowID);
                window.ConstructWindow(_progress, windowID, this, _saveLoad, _gameFactory, _uiFactory);
                _windows[windowID] = window;
            }

            return window;
        }

        public void Open(WindowId windowID, bool closePopUp=false)
        {
            // Has active pop up window (full-screen windows are disabled)
            if (_currentPopup != PopupWindowId.Unknown)
                return;

            var window = GetWindow(windowID);

            // Hide all windows except hub and target window
            foreach (var windowPair in _windows)
            {
                if (windowPair.Key != windowID)    
                    windowPair.Value.gameObject.SetActive(false);
            }

            _previousWindow = _currentWindow;
            _currentWindow = windowID;

            window.OnOpened();
            window.gameObject.SetActive(true);
        }

        public void ReturnToPreviousWindow() 
            => Open(_previousWindow);

        private void OpenHubMenu(object sender, EventArgs e) 
            => Open(WindowId.Hub);
    }
}