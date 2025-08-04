using _Project.HighVoltage.Scripts.UI.GameWindows;
using _Project.Infrastructure.InGameTime;
using _Project.Infrastructure.SaveLoad;
using _Project.Services.CurrentLevelProgress;
using _Project.Services.PlayerProgress;
using _Project.UI.GameWindows;
using _Project.UI.Services;
using _Project.UI.Services.GameWindows;

namespace _Project.Services.States
{
    public class LoopLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoad _saveLoad;
        private readonly IPersistentProgress _progress;
        private readonly IInGameTimeService _timeService;
        private readonly IGameWindow _gameWindow;
        private readonly ILevelProgress _levelProgress;
        private InGameHUD _inGameHUD;
        private bool _isWaveOngoing;

        public LoopLevelState(GameStateMachine gameStateMachine, ISaveLoad saveLoad,
            IGameWindow gameWindow, ILevelProgress levelProgress)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoad = saveLoad;
            _gameWindow = gameWindow;
            _levelProgress = levelProgress;
        }

        public void Enter()
        {
            _inGameHUD = _gameWindow.GetWindow(GameWindowId.InGameHUD).GetComponent<InGameHUD>();
            BeforeGameHUD beforeGameHUD = _gameWindow.GetWindow(GameWindowId.BeforeGameHUD).GetComponent<BeforeGameHUD>();
            beforeGameHUD.PlayerReadyToStart += (_, __) =>
            {
                StartGame();
            };

            _inGameHUD.NextWaveTimerIsUp += (_, __) =>
            {
            };
            _levelProgress.WaveCleared += (_, __) =>
            {
                _inGameHUD.SetNextWaveTimer(_levelProgress.GetCurrentWaveTimer());
            };
            _levelProgress.LevelCleared += (_, __) =>
            {
                _gameStateMachine.Enter<FinishedLevelState>();
            };
            _levelProgress.PlayerCoreDestroyed += (_, __) =>
            {
                _gameStateMachine.Enter<FinishedLevelState>();
            };
        }

        private void StartGame()
        {
            _inGameHUD.SetNextWaveTimer(_levelProgress.LoadedWave.SecondsDelayBeforeWave);
            _gameWindow.Open(GameWindowId.InGameHUD);
        }

        public void Exit()
        {
            _timeService.RestoreTimePassage();
            _gameWindow
                .GetWindow(GameWindowId.InGameHUD)
                .GetComponent<InGameHUD>();
            _gameWindow.CleanUp();
        }
    }
}