using _Project.MVVM;
using _Project.Services;
using _Project.Services.AssetManagement;
using _Project.StaticData;
using _Project.UI.Views;
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

        public TView CreateViewWithInjection<TView>() where TView : View
        {
            if (_uiRoot == null)
                CreateUIRoot();

            TView view = _assets.Instantiate<TView>(AssetPath.MoneyUI);
            GameObjectInjector.InjectObject(view.gameObject, view.gameObject.scene.GetSceneContainer());
            return view;
        }
    }
}