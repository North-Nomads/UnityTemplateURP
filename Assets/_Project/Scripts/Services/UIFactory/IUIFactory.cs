using System.Collections.Generic;
using _Project.UI.GameWindows;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using _Project.UI.Windows;
using UnityEngine;

namespace _Project.UI.Services.Factory
{
    public interface IUIFactory 
    {
        void CreateUIRoot();
        WindowBase InstantiateWindow(WindowId windowID);
        GameWindowBase InstantiateWindow(GameWindowId windowID);
        List<LevelSelectButton> InstantiateLevelButtons(int totalLevels, Transform parent);
    }
}