using _Project.Services.AssetManagement;
using _Project.StaticData;
using _Project.UI.GameWindows;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using _Project.UI.Windows;
using Reflex.Extensions;
using Reflex.Injectors;
using UnityEngine;

namespace _Project.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "Prefabs/UI/UIRoot";

        private readonly IStaticData _staticData;
        private readonly IAssetProvider _assets;
        private Transform _uiRoot;

        public UIFactory(IAssetProvider assets, IStaticData staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public void CreateUIRoot()
            => _uiRoot = _assets.Instantiate(UIRootPath).transform;

        public WindowBase InstantiateWindow(HubWindowId hubWindowId)
        {
            HubWindowConfig config = _staticData.ForWindow(hubWindowId);
            WindowBase window = Object.Instantiate(config.Prefab, _uiRoot);
            GameObjectInjector.InjectRecursive(window.gameObject, window.gameObject.scene.GetSceneContainer());
            window.transform.SetAsFirstSibling();
            window.gameObject.SetActive(false);
            return window;
        }

        public GameWindowBase InstantiateWindow(GameWindowId windowID)
        {
            GameWindowConfig config = _staticData.ForGameWindow(windowID);
            GameWindowBase window = Object.Instantiate(config.Prefab, _uiRoot);
            GameObjectInjector.InjectRecursive(window.gameObject, window.gameObject.scene.GetSceneContainer());
            window.transform.SetAsFirstSibling();
            window.gameObject.SetActive(false);
            return window;
        }
    }
}