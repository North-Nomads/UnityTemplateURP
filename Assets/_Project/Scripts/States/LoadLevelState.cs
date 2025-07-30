using Template._Project.Scripts.Services.GameFactory;
using Template._Project.Scripts.Services.StaticData;
using Template._Project.Scripts.Services.UIFactory;
using UnityEngine;

namespace Template._Project.Scripts.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactoryService _gameFactory;
        private readonly IStaticDataService _staticData;
        private readonly ISceneLoader _sceneLoader;
        private readonly Canvas _loadingCurtain;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, IGameFactoryService gameFactory, 
            IStaticDataService staticData, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _staticData = staticData;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.gameObject.SetActive(true);
            _sceneLoader.Load(sceneName, onLoaded: OnLoaded);
        }

        public void Exit() 
            => _loadingCurtain.gameObject.SetActive(false);

        private void OnLoaded()
        {
            _uiFactory.InstantiateWindow(HubWindowId.Hub);
            /*LevelConfig config = _staticData.ForLevel(_progressService.Progress.CurrentLevel);
            PlayerCore playerCore = InitializeGameWorld(config);
            _levelProgress.LoadLevelConfig(config, playerCore);
            _buildingStore.ResetMoney();
            InitializeMobSpawners();
            _buildingService.MapTilemap = Object.FindObjectOfType<Tilemap>(); //if it works
            _buildingService.OnSceneLoaded();
            InitializeBuilder();
            InitializeInGameHUD();
            InitializeCamera();
            _buildingStore.AddMoney(config.InitialMoney);
            _gameStateMachine.Enter<GameLoopState>();*/
        }

        private void InitializeCamera()
        {
            /*GameObject cameraSpawnPoint = GameObject.FindGameObjectWithTag(Constants.CameraSpawnPoint);
            _cameraService.InitializeCamera(cameraSpawnPoint.transform.position);*/
        }

        private void InitializeBuilder()
        {
            /*PlayerBuildBehaviour playerBuildBehaviour = _gameFactory.CreateBuilder();
            playerBuildBehaviour.Initialize(_staticData, _buildingService, _gameWindowService);*/
        }

        /*private PlayerCore InitializeGameWorld(LevelConfig config)
        {
            /*PlayerCore playerCore = InitializePlayerBase(config);
            return playerCore;#1#
        }*/

        private void InitializeInGameHUD()
        {
            /*_uiFactory.CreateUIRoot();
            _gameWindowService.GetWindow(GameWindowId.InGameHUD)
                .GetComponent<InGameHUD>()
                .ProvideSceneData(_buildingService, _buildingStore);
            _gameWindowService.GetWindow(GameWindowId.EndGame);
            _gameWindowService.GetWindow(GameWindowId.BeforeGameHUD);
            InitializePauseMenu();
            _gameWindowService.Open(GameWindowId.BeforeGameHUD);*/
        }

        private void InitializePauseMenu()
        {
            /*InGamePauseMenu pauseMenu = _gameWindowService.GetWindow(GameWindowId.InGamePauseMenu)
                .GetComponent<InGamePauseMenu>();
            pauseMenu.RestartButtonPressed += (_, _) =>
                _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
            pauseMenu.ReturnToMenuButtonPressed += (_, _) => _gameStateMachine.Enter<HubState>();*/
        }

        /*private PlayerCore InitializePlayerBase(LevelConfig config)
        {
            /*PlayerCore playerCore = _gameFactory.CreatePlayerCore(GameObject.FindGameObjectWithTag(Constants.CoreSpawnPoint));
            
            playerCore.Initialize(_mobSpawnerService, config);
            return playerCore;#1#
        }*/


        private void InitializeMobSpawners()
        {
            /*WaypointHolder[] spawnerSpots = Object.FindObjectsByType<WaypointHolder>(FindObjectsSortMode.None);
            
            _mobSpawnerService.LoadConfigToSpawners(_levelProgress.LoadedWave, spawnerSpots,
                _levelProgress.LoadedLevelConfig.DeltaBetweenSpawns);*/
        }
    }
}