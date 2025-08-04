using System;
using System.Collections.Generic;
using _Project.Services.Factory;
using _Project.Infrastructure.SaveLoad;
using _Project.Services.PlayerProgress;
using _Project.UI.Services.Factory;
using _Project.UI.Windows;

namespace _Project.UI.Services.Windows
{
    public class WindowContainer : IWindowContainer
    {
        private FullScreenWindowId _previousFullScreenWindow;
        private FullScreenWindowId _currentFullScreenWindow;
        private readonly Dictionary<FullScreenWindowId, WindowBase> _windows;

        private readonly IUIFactory _uiFactory;
        private readonly IPersistentProgress _progress;
        private readonly ISaveLoad _saveLoad;
        private readonly IGameFactory _gameFactory;

        public WindowContainer(IUIFactory uiFactory, IPersistentProgress progress,
            ISaveLoad saveLoad, IGameFactory gameFactory)
        {
            _uiFactory = uiFactory;
            _progress = progress;
            _saveLoad = saveLoad;
            _windows = new Dictionary<FullScreenWindowId, WindowBase>();
            _gameFactory = gameFactory;
        }

        public void CleanUp()
        {
            _currentFullScreenWindow = FullScreenWindowId.Hub;
            _previousFullScreenWindow = FullScreenWindowId.Unknown;
            _windows.Clear();
        }

        public WindowBase GetWindow(FullScreenWindowId fullScreenWindowId)
        {
            _windows.TryGetValue(fullScreenWindowId, out var window);
            if (window == null)
            {
                window = _uiFactory.InstantiateWindow(fullScreenWindowId);
                window.ConstructWindow(_progress, fullScreenWindowId, this, _saveLoad, _gameFactory, _uiFactory);
                _windows[fullScreenWindowId] = window;
            }

            return window;
        }

        public void Open(FullScreenWindowId fullScreenWindowId, bool closePopUp=false)
        {
            var window = GetWindow(fullScreenWindowId);

            // Hide all windows except hub and target window
            foreach (var windowPair in _windows)
            {
                if (windowPair.Key != fullScreenWindowId)    
                    windowPair.Value.gameObject.SetActive(false);
            }

            _previousFullScreenWindow = _currentFullScreenWindow;
            _currentFullScreenWindow = fullScreenWindowId;

            window.OnOpened();
            window.gameObject.SetActive(true);
        }

        public void ReturnToPreviousWindow() 
            => Open(_previousFullScreenWindow);

        private void OpenHubMenu(object sender, EventArgs e) 
            => Open(FullScreenWindowId.Hub);
    }
}