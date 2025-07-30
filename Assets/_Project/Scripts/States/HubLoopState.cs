using Template._Project.Scripts.Services.AssetProvider;
using Template._Project.Scripts.Services.GameFactory;
using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.UIFactory;

namespace Template._Project.Scripts.States
{
    public class HubLoopState : IState
    {
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IGameFactoryService _gameFactoryService;
        private readonly IAssetProviderService _assetProvider;
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public HubLoopState(GameStateMachine gameStateMachine, IGameFactoryService gameFactoryService,
            IPersistentProgressService persistentProgress, IAssetProviderService assetProvider, ISceneLoader sceneLoader,
            IUIFactory uiFactory)
        {
            _stateMachine = gameStateMachine;
            _gameFactoryService = gameFactoryService;
            _persistentProgress = persistentProgress;
            _assetProvider = assetProvider;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _sceneLoader.Load(ScenePath.HubSceneName, onLoaded: InitializeScene);
        }

        public void Exit()
        {
            
        }

        private void InitializeScene()
        {
            InformProgressReaders();
            InitializeUI();
        }

        private void InitializeUI() 
            => _uiFactory.InstantiateWindow(HubWindowId.Hub);

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader saveService in _gameFactoryService.ProgressReaders)
                saveService.LoadProgress(_persistentProgress.PlayerProgress);
        }
    }
}