using System.Collections.Generic;
using Template._Project.Scripts.Services.AssetProvider;
using Template._Project.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Template._Project.Scripts.Services.GameFactory
{
    public class GameFactoryService : IGameFactoryService
    {
        private readonly IAssetProviderService _assetProvider;
        
        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgressReadWriter> ProgressWriters { get; } = new();
        
        public GameFactoryService(IAssetProviderService assetProvider)
        {
            _assetProvider = assetProvider;
        }

        private void InstantiateRegistered(string prefabPath, Vector3 position = default, Transform parent = null,
            Quaternion rotation = default)
        {
            GameObject instance = _assetProvider.Instantiate(prefabPath, position, parent, rotation);
            RegisterProgressWatchers(instance);
        }

        private T InstantiateRegistered<T>(string prefabPath, Vector3 position = default, Transform parent = null,
            Quaternion rotation = default) where T : MonoBehaviour
        {
            T instance = _assetProvider.Instantiate<T>(prefabPath, position, parent, rotation);
            RegisterProgressWatchers(instance.gameObject);
            return instance;
        }

        /// <summary>
        /// Parses all Unity.GameObject inner components in search of Progress Readers / Writers and to send them to
        /// progress watcher lists 
        /// </summary>
        /// <param name="gameObject"></param>
        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                AddComponentToProgressWatchers(progressReader);
        }

        /// <summary>
        /// Adds passed as argument component into list of progress readers and writers 
        /// </summary>
        /// <param name="progressReader">Component of game object that require progress reading or writing</param>
        private void AddComponentToProgressWatchers(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgressReadWriter progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}