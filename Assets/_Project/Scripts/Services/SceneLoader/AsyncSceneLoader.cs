using System;
using UnityEngine;
using System.Collections;
using _Project.Infrastructure;
using UnityEngine.SceneManagement;

namespace _Project.Services.SceneLoader
{
    public class AsyncSceneLoader : ISceneLoader
    {
        public void Load(string name, Action onLoaded = null) 
            => SingletonCoroutineRunner.RunRoutine(LoadScene(name, onLoaded));

        public IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);
            
            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}