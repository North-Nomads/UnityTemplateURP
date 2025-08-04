using System;
using _Project.UI.GameWindows;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using _Project.UI.Windows;

namespace _Project.StaticData
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }

    [Serializable]
    public class GameWindowConfig
    {
        public GameWindowId WindowId;
        public GameWindowBase Prefab;
    }
}