using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.SaveLoad;
using Template._Project.Scripts.TimeManagement;

namespace Template._Project.Scripts.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoad;
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IInGameTimeService _inGameTime;
        private bool _isWaveOngoing;

        public GameLoopState(GameStateMachine gameStateMachine, ISaveLoadService saveLoad, 
            IPersistentProgressService persistentProgress, IInGameTimeService inGameTime)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoad = saveLoad;
            _persistentProgress = persistentProgress;
            _inGameTime = inGameTime;
        }

        public void Enter()
        {
            /*_inGameHUD = _gameWindowService.GetWindow(GameWindowId.InGameHUD).GetComponent<InGameHUD>();
            BeforeGameHUD beforeGameHUD = _gameWindowService.GetWindow(GameWindowId.BeforeGameHUD).GetComponent<BeforeGameHUD>();
            beforeGameHUD.PlayerReadyToStart += (_, __) =>
            {
                StartGame();
                _playerBuilding.ToggleBuildingAllowance(true);
            };

            _inGameHUD.NextWaveTimerIsUp += (_, __) =>
            {
                _mobSpawnerService.UpdateWaveOngoingStatus(true);
                _mobSpawnerService.LaunchMobSpawning();
            };
            _levelProgress.WaveCleared += (_, __) =>
            {
                _mobSpawnerService.UpdateWaveOngoingStatus(false);
                _mobSpawnerService.UpdateWaveContent(_levelProgress.LoadedWave);
                _inGameHUD.SetNextWaveTimer(_levelProgress.GetCurrentWaveTimer());
            };
            _levelProgress.LevelCleared += (_, __) =>
            {
                _mobSpawnerService.UpdateWaveOngoingStatus(false);
                _playerBuilding.ToggleBuildingAllowance(false);
                _gameStateMachine.Enter<GameFinishedState>();
            };
            _levelProgress.PlayerCoreDestroyed += (_, __) =>
            {
                _gameStateMachine.Enter<GameFinishedState>();
            };*/
        }

        /*
        private void StartGame()
        {
            _inGameHUD.SetNextWaveTimer(_levelProgress.LoadedWave.SecondsDelayBeforeWave);
            _gameWindowService.Open(GameWindowId.InGameHUD);
        }
        */

        public void Exit()
        {
            /*_timeService.RestoreTimePassage();
            _gameWindowService
                .GetWindow(GameWindowId.InGameHUD)
                .GetComponent<InGameHUD>()
                .OnLevelEnded(_buildingStore);
            _gameWindowService.CleanUp();*/
        }
    }
}