using Reflex.Extensions;
using Reflex.Injectors;
using Template._Project.Scripts.Data;
using Template._Project.Scripts.Services.AssetProvider;
using Template._Project.Scripts.Services.PersistentProgress;
using Template._Project.Scripts.Services.StaticData;
using UnityEngine;

namespace Template._Project.Scripts.Services.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "Prefabs/UI/UIRoot";

        private readonly IPersistentProgressService _playerProgress;
        private readonly IAssetProviderService _assetsProvider;
        private readonly IStaticDataService _staticData;
        private Transform _uiRoot;

        private Transform UIRoot
        {
            get
            {
                if (_uiRoot == null)
                    _uiRoot = _assetsProvider.Instantiate(AssetPath.UIRootPath).transform;
                return _uiRoot;
            }
        }

        public UIFactory(IAssetProviderService assetsProvider, IPersistentProgressService playerProgress, IStaticDataService staticData)
        {
            _assetsProvider = assetsProvider;
            _playerProgress = playerProgress;
            _staticData = staticData;
        }

        public HubWindowBase InstantiateWindow(HubWindowId hubWindowId)
        {
            HubWindowConfig windowConfig = _staticData.ForHubWindow(hubWindowId);
            HubWindowBase window = _assetsProvider.Instantiate(windowConfig.Prefab, UIRoot);
            GameObjectInjector.InjectRecursive(window.gameObject, window.gameObject.scene.GetSceneContainer());
            window.transform.SetAsFirstSibling();
            window.gameObject.SetActive(false);
            return window;
        }

        public GameWindowBase InstantiateWindow(GameWindowId windowID)
        {
            GameWindowConfig windowConfig = _staticData.ForGameWindow(windowID);
            GameWindowBase window = _assetsProvider.Instantiate(windowConfig.Prefab);
            window.transform.SetAsFirstSibling();
            window.gameObject.SetActive(false);
            return window;
        }
    }
}