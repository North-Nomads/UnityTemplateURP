using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.TimeManagement;
using UnityEngine.SceneManagement;

namespace Template._Project.Scripts.States
{
    public class GameFinishedState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly IInGameTimeService _timeService;

        public GameFinishedState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, 
            IInGameTimeService timeService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _timeService = timeService;
        }

        public void Enter()
        {
            /*EndGameWindow endGameWindow = _gameWindowService.GetWindow(GameWindowId.EndGame).GetComponent<EndGameWindow>();
            _gameWindowService.Open(GameWindowId.EndGame);
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
                _progressService.IncrementCurrentLevel();
                if (_playerProgress.Progress.CurrentLevel >= Constants.TotalLevels)
                    _gameStateMachine.Enter<HubState>();
                else
                    _gameStateMachine.Enter<LoadLevelState, string>($"Level{_playerProgress.Progress.CurrentLevel}");
            };*/
        }

        public void Exit() 
        {
            _timeService.RestoreTimePassage();
        }
    }
}