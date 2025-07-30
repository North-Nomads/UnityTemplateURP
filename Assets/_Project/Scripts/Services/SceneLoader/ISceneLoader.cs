using System;
using System.Collections;

namespace Template._Project.Scripts.States
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null);
        IEnumerator LoadScene(string name, Action onLoaded = null);
    }
}