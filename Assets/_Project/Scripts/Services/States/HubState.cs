using System.Collections.Generic;
using UnityEngine;
using _Project.Services.AssetManagement;
using _Project.Services.Factory;
using _Project.Services.PlayerProgress;
using _Project.UI.Services.Factory;
using _Project.UI.Services.Windows;

namespace _Project.Services.States
{
    public class HubState : IState
    {
        public IEnumerable<ISavedProgressReader> SaveReaderServices { get; }
        private readonly IPersistentProgress _progress;
        private readonly GameStateMachine _stateMachine;
        private readonly IWindowService _windowService;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IEnumerator<ISavedProgressReader> _saveReaderServices;

        public HubState(GameStateMachine gameStateMachine,
            IGameFactory gameFactory, IPersistentProgress progress, IUIFactory uiFactory, 
            IWindowService windowService, IEnumerable<ISavedProgressReader> saveReaderServices,
            IAssetProvider assetProvider)
        {
            SaveReaderServices = saveReaderServices;
            _stateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _progress = progress;
            _uiFactory = uiFactory;
            _windowService = windowService;
            _assetProvider = assetProvider;
        }

        public void Enter()
        {
            _windowService.CleanUp();
        }

        public void Exit()
        {
            
        }
    }
}