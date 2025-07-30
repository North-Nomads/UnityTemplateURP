using UnityEngine;

namespace Template._Project.Scripts.Services.AssetProvider
{
    public interface IAssetProviderService
    {
        public GameObject Instantiate(string pathToPrefab);
        public GameObject Instantiate(string pathToPrefab, Vector3 position);
        public GameObject Instantiate(string pathToPrefab, Transform parent);
        public GameObject Instantiate(string pathToPrefab, Vector3 position, Transform parent);
        public GameObject Instantiate(string pathToPrefab, Vector3 position, Transform parent, Quaternion rotation);
        public T Instantiate<T>(string pathToPrefab) where T : MonoBehaviour;
        public T Instantiate<T>(string pathToPrefab, Vector3 position) where T : MonoBehaviour;
        public T Instantiate<T>(string pathToPrefab, Vector3 position, Transform parent) where T : MonoBehaviour;
        public T Instantiate<T>(string pathToPrefab, Transform parent) where T : MonoBehaviour;
        public T Instantiate<T>(string pathToPrefab, Vector3 position, Transform parent, Quaternion rotation)
            where T : MonoBehaviour;
        public T Instantiate<T>(T prefab) where T : MonoBehaviour;
        public T Instantiate<T>(T prefab, Vector3 position) where T : MonoBehaviour;
        public T Instantiate<T>(T prefab, Vector3 position, Transform parent) where T : MonoBehaviour;
        public T Instantiate<T>(T prefab, Transform parent) where T : MonoBehaviour;
        public T Instantiate<T>(T prefab, Vector3 position, Transform parent, Quaternion rotation)
            where T : MonoBehaviour;
    }
}