using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.SaveLoad;
using UnityEngine;

namespace Template._Project.Scripts.States
{
    public class LoadProgressState : IState
    {
        private readonly IPersistentProgressService _persistentProgress;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoad;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService persistentProgress,
            ISaveLoadService saveLoad)
        {
            _gameStateMachine = gameStateMachine;
            _persistentProgress = persistentProgress;
            _saveLoad = saveLoad;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<HubLoopState>();
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _persistentProgress.PlayerProgress = _saveLoad.LoadProgress() ?? NewProgress();
            Debug.Log($"Player progress loaded / inited: {_persistentProgress.PlayerProgress}");
        }

        private PlayerProgress NewProgress() 
            => new();
    }
}