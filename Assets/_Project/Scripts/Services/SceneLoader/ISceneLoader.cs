using System;
using System.Collections;

namespace _Project.Services.SceneLoader
{
    public interface ISceneLoader
    {
        IEnumerator LoadScene(string name, Action onLoaded = null);
    }
}