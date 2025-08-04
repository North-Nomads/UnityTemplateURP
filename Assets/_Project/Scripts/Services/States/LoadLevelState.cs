using _Project.Services.Factory;
using _Project.Services.CurrentLevelProgress;
using _Project.Services;
using _Project.Services.PlayerProgress;
using _Project.StaticData;
using _Project.UI.GameWindows;
using _Project.UI.Services;
using _Project.UI.Services.Factory;
using _Project.UI.Services.GameWindows;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Services.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IPersistentProgress _progress;
        private readonly IGameWindow _gameWindow;
        private readonly IUIFactory _uiFactory;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IStaticData _staticData;
        private readonly IGameFactory _gameFactory;
        private readonly Canvas _loadingCurtain;
        private readonly ILevelProgress _levelProgress;

        public LoadLevelState(GameStateMachine gameStateMachine,
            IGameFactory gameFactory, IPersistentProgress progress,
            IStaticData staticData, IGameWindow gameWindow, IUIFactory uiFactory,
            ILevelProgress levelProgress)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _progress = progress;
            _staticData = staticData;
            _gameWindow = gameWindow;
            _uiFactory = uiFactory;
            _levelProgress = levelProgress;
        }

        public void Enter(string sceneName)
        {
            _gameFactory.CleanUp();
            _loadingCurtain.gameObject.SetActive(true);
        }

        public void Exit() 
            => _loadingCurtain.gameObject.SetActive(false);

        private void OnLoaded()
        {
            LevelConfig config = _staticData.ForLevel(_progress.Progress.CurrentLevel);
            _levelProgress.LoadLevelConfig(config);
            InitializeInGameHUD();
            InitializeCamera();
            _gameStateMachine.Enter<LoopLevelState>();
        }

        private void InitializeCamera()
        {
            GameObject cameraSpawnPoint = GameObject.FindGameObjectWithTag(Constants.CameraSpawnPoint);
        }

        private void InitializeInGameHUD()
        {
            _uiFactory.CreateUIRoot();
            _gameWindow.GetWindow(GameWindowId.InGameHUD)
                .GetComponent<InGameHUD>();
            _gameWindow.GetWindow(GameWindowId.EndGame);
            _gameWindow.GetWindow(GameWindowId.BeforeGameHUD);
            InitializePauseMenu();
            _gameWindow.Open(GameWindowId.BeforeGameHUD);
        }

        private void InitializePauseMenu()
        {
            InGamePauseMenu pauseMenu = _gameWindow.GetWindow(GameWindowId.InGamePauseMenu)
                .GetComponent<InGamePauseMenu>();
            pauseMenu.RestartButtonPressed += (_, _) =>
                _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
            pauseMenu.ReturnToMenuButtonPressed += (_, _) => _gameStateMachine.Enter<HubState>();
        }
    }
}