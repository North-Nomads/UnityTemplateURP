using System;
using System.Collections.Generic;
using _Project.Infrastructure.InGameTime;
using _Project.Infrastructure.SaveLoad;
using _Project.Services.AssetManagement;
using _Project.Services.CurrentLevelProgress;
using _Project.Services.Factory;
using _Project.Services.PlayerProgress;
using _Project.Services.SceneLoader;
using _Project.StaticData;
using _Project.UI.Services.Factory;
using _Project.UI.Services.Windows;
using UnityEngine;

namespace _Project.Services.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(IPersistentProgress persistentProgress, ISaveLoad saveLoad, IGameFactory gameFactory,
            IUIFactory uiFactory, IWindowContainer windowContainer, IAssetProvider assetProvider,
            IStaticData staticData, ILevelProgress levelProgress, IInGameTimeService timeService,
            IEnumerable<ISavedProgressReader> saveReaderServices, ISceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgress, saveLoad),
                [typeof(LoadHubState)] = new LoadHubState(this, windowContainer, sceneLoader),
                [typeof(HubState)] = new HubState(this, saveReaderServices, windowContainer),
                [typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, persistentProgress, staticData, uiFactory, levelProgress),
                [typeof(LoopLevelState)] = new LoopLevelState(this, saveLoad, levelProgress),
                [typeof(FinishedLevelState)] = new FinishedLevelState(this, persistentProgress, persistentProgress, timeService)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            // The first state could be null on program start 
            _currentState?.Exit();
            TState state = GetState<TState>();
            Debug.Log($"State changed: {_currentState?.ToString() ?? "None"} => {state}");
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
            => _states[typeof(TState)] as TState;
    }
}