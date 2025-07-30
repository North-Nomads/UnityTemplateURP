using Reflex.Core;
using UnityEngine;

namespace Template._Project.Scripts.Infrastructure
{
    /// <summary>
    /// Scene Context for DI. Populate classes with (MonoBehaviour, IInstaller) for another scene context
    /// </summary>
    public class SampleSceneInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton("World");
        }
    }
}