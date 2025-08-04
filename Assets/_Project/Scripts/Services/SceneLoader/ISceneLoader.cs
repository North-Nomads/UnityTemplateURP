using System;
using System.Collections;

namespace _Project.Scripts.Services.SceneLoader
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null);
        IEnumerator LoadScene(string name, Action onLoaded = null);
    }
}