using _Project.Infrastructure.InGameTime;
using _Project.Infrastructure.SaveLoad;
using _Project.Scripts.Services.SceneLoader;
using _Project.Services.AssetManagement;
using _Project.Services.Factory;
using _Project.Services.States;
using _Project.Services.CurrentLevelProgress;
using _Project.Services.PlayerProgress;
using _Project.StaticData;
using _Project.UI.Services.Factory;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using Reflex.Core;
using UnityEngine;

namespace _Project.Infrastructure
{
    /// <summary>
    /// Defines the bindings to the root global container
    /// </summary>
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        /// <summary>
        /// Reflex looks for & uses IInstaller instance to build a DI container
        /// </summary>
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(AssetProvider), typeof(IAssetProvider));
            builder.AddSingleton(typeof(PersistentProgress), typeof(IPersistentProgress));
            builder.AddSingleton(typeof(PlayerPrefsSaveLoad), typeof(ISaveLoad));
            builder.AddSingleton(typeof(ScriptableStaticData), typeof(IStaticData));
            builder.AddSingleton(typeof(AsyncSceneLoader), typeof(ISceneLoader));

            builder.AddScoped(typeof(GameFactory), typeof(IGameFactory), typeof(ISavedProgressReader),
                typeof(IProgressUpdater));
            builder.AddScoped(typeof(UIFactory), typeof(IUIFactory));
            builder.AddScoped(typeof(LevelProgress), typeof(ILevelProgress));
            builder.AddScoped(typeof(InGameTimeService), typeof(IInGameTimeService));
            builder.AddScoped(typeof(WindowContainer), typeof(IWindowContainer));
            builder.AddScoped(typeof(GameWindow), typeof(IGameWindow));
            

            builder.AddSingleton(typeof(GameStateMachine));
            builder.OnContainerBuilt += container => container.Single<GameStateMachine>().Enter<BootstrapState>();
        }
    }
}