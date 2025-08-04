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
        private HubWindowId _previousHubWindow;
        private HubWindowId _currentHubWindow;
        private readonly Dictionary<HubWindowId, WindowBase> _windows;

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
            _windows = new Dictionary<HubWindowId, WindowBase>();
            _gameFactory = gameFactory;
        }

        public void CleanUp()
        {
            _currentHubWindow = HubWindowId.Hub;
            _previousHubWindow = HubWindowId.Unknown;
            _windows.Clear();
        }

        public WindowBase GetWindow(HubWindowId hubWindowId)
        {
            _windows.TryGetValue(hubWindowId, out var window);
            if (window == null)
            {
                window = _uiFactory.InstantiateWindow(hubWindowId);
                
                window.ConstructWindow(_progress, hubWindowId, this, _saveLoad, _gameFactory, _uiFactory);
                _windows[hubWindowId] = window;
            }

            return window;
        }

        public void Open(HubWindowId hubWindowId, bool closePopUp=false)
        {
            var window = GetWindow(hubWindowId);

            // Hide all windows except hub and target window
            foreach (var windowPair in _windows)
            {
                if (windowPair.Key != hubWindowId)    
                    windowPair.Value.gameObject.SetActive(false);
            }

            _previousHubWindow = _currentHubWindow;
            _currentHubWindow = hubWindowId;

            window.OnOpened();
            window.gameObject.SetActive(true);
        }

        public void ReturnToPreviousWindow() 
            => Open(_previousHubWindow);

        private void OpenHubMenu(object sender, EventArgs e) 
            => Open(HubWindowId.Hub);
    }
}