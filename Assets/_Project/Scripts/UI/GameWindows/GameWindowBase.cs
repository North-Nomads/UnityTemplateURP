using _Project.Services.CurrentLevelProgress;
using _Project.UI.Services.GameWindows;
using UnityEngine;

namespace _Project.UI.GameWindows
{
    public abstract class GameWindowBase : MonoBehaviour
    {
        protected IGameWindow GameWindow;
        protected ILevelProgress LevelProgress;

        public virtual void ConstructWindow(IGameWindow gameWindow, ILevelProgress levelProgress)
        {
            GameWindow = gameWindow;
            LevelProgress = levelProgress;
        }

        public virtual void OnOpened() { }
        public virtual void OnClosed() { }

        protected void CloseWindow()
            => GameWindow.ReturnToPreviousWindow();

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