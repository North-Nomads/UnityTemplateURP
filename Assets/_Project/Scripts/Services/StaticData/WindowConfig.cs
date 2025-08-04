using System;
using _Project.UI.GameWindows;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using _Project.UI.Windows;
using UnityEngine.Serialization;

namespace _Project.StaticData
{
    [Serializable]
    public class WindowConfig
    {
        [FormerlySerializedAs("WindowId")] public FullScreenWindowId fullScreenWindowId;
        public WindowBase Prefab;
    }

    [Serializable]
    public class GameWindowConfig
    {
        public GameWindowId WindowId;
        public GameWindowBase Prefab;
    }
}