using _Project.Services.Factory;
using _Project.Infrastructure.SaveLoad;
using _Project.Services.PlayerProgress;
using _Project.UI.Services.Factory;
using _Project.UI.Services.Windows;
using UnityEngine;

namespace _Project.UI.Windows
{

    public abstract class WindowBase : MonoBehaviour
    {
        protected IPersistentProgress PersistentProgress;
        protected WindowId ThisWindowId;
        protected IWindowService WindowService;
        protected ISaveLoad SaveLoad;
        protected IGameFactory GameFactory;
        protected IUIFactory UIFactory;

        public virtual void ConstructWindow(IPersistentProgress progress,
            WindowId windowId, IWindowService windowService, ISaveLoad saveLoad, IGameFactory gameFactory,
            IUIFactory uiFactory)
        {
            PersistentProgress = progress;
            ThisWindowId = windowId;
            WindowService = windowService;
            SaveLoad = saveLoad;
            GameFactory = gameFactory;
            UIFactory = uiFactory;
        }

        public virtual void OnOpened() { }
        protected void CloseWindow() 
            => WindowService.ReturnToPreviousWindow();
        protected void ReturnToHub()
            => WindowService.Open(WindowId.Hub);
        protected virtual void OnStart()
        {
            Initialize();
            SubscribeUpdates();
        }
        protected virtual void CleanUp() { }
        protected virtual void Initialize() { }
        protected virtual void SubscribeUpdates() { }
        
        private void Start() 
            => OnStart();

        private void OnDestroy()
            => CleanUp();
    }
}