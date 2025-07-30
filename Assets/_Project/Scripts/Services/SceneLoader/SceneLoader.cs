using Template._Project.Scripts.Infrastructure;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using System;

namespace Template._Project.Scripts.States
{
    public class SceneLoader : ISceneLoader
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