using _Project.Infrastructure.InGameTime;
using _Project.Services;
using _Project.Services.PlayerProgress;
using _Project.UI.Services;
using _Project.UI.Services.GameWindows;
using _Project.UI.Windows;
using UnityEngine.SceneManagement;

namespace _Project.Services.States
{
    public class FinishedLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgress _progress;
        private readonly IGameWindow _gameWindow;
        private readonly IPersistentProgress _persistentProgress;
        private readonly IInGameTimeService _timeService;

        public FinishedLevelState(GameStateMachine gameStateMachine, IPersistentProgress progress,
            IGameWindow gameWindow, IPersistentProgress persistentProgress, IInGameTimeService timeService)
        {
            _gameStateMachine = gameStateMachine;
            _progress = progress;
            _gameWindow = gameWindow;
            _persistentProgress = persistentProgress;
            _timeService = timeService;
        }

        public void Enter()
        {
            EndGameWindow endGameWindow = _gameWindow.GetWindow(GameWindowId.EndGame).GetComponent<EndGameWindow>();
            _gameWindow.Open(GameWindowId.EndGame);
            _timeService.EnablePause();
            endGameWindow.ReturnToHubButtonPressed += (_, __) =>
            {
                _gameStateMachine.Enter<LoadProgressState>();
            };
            endGameWindow.RestartLevelButtonPressed += (_, __) =>
            {
                _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
            };
            endGameWindow.LaunchNextLevelButtonPressed += (_, __) =>
            {
                _progress.IncrementCurrentLevel();
                if (_persistentProgress.Progress.CurrentLevel >= Constants.TotalLevels)
                    _gameStateMachine.Enter<HubState>();
                else
                    _gameStateMachine.Enter<LoadLevelState, string>($"Level{_persistentProgress.Progress.CurrentLevel}");
            };
        }

        public void Exit() 
        {
            _timeService.RestoreTimePassage();
        }
    }
}