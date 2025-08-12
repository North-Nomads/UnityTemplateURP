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
        
        private readonly IEnumerator<ISavedProgressReader> _saveReaderServices;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IWindowContainer _windowContainer;

        public HubState(GameStateMachine gameStateMachine, IEnumerable<ISavedProgressReader> saveReaderServices,
            IWindowContainer windowContainer)
        {
            _gameStateMachine = gameStateMachine;
            _windowContainer = windowContainer;
            SaveReaderServices = saveReaderServices;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
            
        }
    }
}