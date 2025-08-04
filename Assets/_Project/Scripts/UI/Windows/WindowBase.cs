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
        protected FullScreenWindowId ThisFullScreenWindowId;
        protected IWindowContainer WindowContainer;
        protected ISaveLoad SaveLoad;
        protected IGameFactory GameFactory;
        protected IUIFactory UIFactory;

        public virtual void ConstructWindow(IPersistentProgress progress,
            FullScreenWindowId fullScreenWindowId, IWindowContainer windowContainer, ISaveLoad saveLoad, IGameFactory gameFactory,
            IUIFactory uiFactory)
        {
            PersistentProgress = progress;
            ThisFullScreenWindowId = fullScreenWindowId;
            WindowContainer = windowContainer;
            SaveLoad = saveLoad;
            GameFactory = gameFactory;
            UIFactory = uiFactory;
        }

        public virtual void OnOpened() { }
        protected void CloseWindow() 
            => WindowContainer.ReturnToPreviousWindow();
        protected void ReturnToHub()
            => WindowContainer.Open(FullScreenWindowId.Hub);
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