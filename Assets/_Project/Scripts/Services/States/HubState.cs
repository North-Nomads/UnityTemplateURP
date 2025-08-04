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
        private readonly IWindowContainer _windowContainer;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IEnumerator<ISavedProgressReader> _saveReaderServices;

        public HubState(GameStateMachine gameStateMachine,
            IGameFactory gameFactory, IPersistentProgress progress, IUIFactory uiFactory, 
            IWindowContainer windowContainer, IEnumerable<ISavedProgressReader> saveReaderServices,
            IAssetProvider assetProvider)
        {
            SaveReaderServices = saveReaderServices;
            _stateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _progress = progress;
            _uiFactory = uiFactory;
            _windowContainer = windowContainer;
            _assetProvider = assetProvider;
        }

        public void Enter()
        {
            _windowContainer.CleanUp();
        }

        public void Exit()
        {
            
        }
    }
}