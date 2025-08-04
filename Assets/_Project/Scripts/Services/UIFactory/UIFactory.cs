using System.Collections.Generic;
using _Project.Services.AssetManagement;
using _Project.Services.PlayerProgress;
using _Project.StaticData;
using _Project.UI.GameWindows;
using _Project.UI.Services.GameWindows;
using _Project.UI.Services.Windows;
using _Project.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "Prefabs/UI/UIRoot";
        private const string CharacterButtonPath = "Prefabs/UI/HUB/Windows/CharacterCard_Button";

        private readonly IPersistentProgress _persistentProgress;
        private readonly IStaticData _staticData;
        private readonly IAssetProvider _assets;
        private Transform _uiRoot;

        public UIFactory(IAssetProvider assets, IPersistentProgress persistentProgress, IStaticData staticData)
        {
            _assets = assets;
            _persistentProgress = persistentProgress;
            _staticData = staticData;
        }

        public void CreateUIRoot()
            => _uiRoot = _assets.Instantiate(UIRootPath).transform;

        public WindowBase InstantiateWindow(FullScreenWindowId fullScreenWindowId)
        {
            var window = CreateSpecificWindow(fullScreenWindowId);
            window.transform.SetAsFirstSibling();
            window.gameObject.SetActive(false);
            return window;

            WindowBase CreateSpecificWindow(FullScreenWindowId windowId)
            {
                return windowId switch
                {
                    FullScreenWindowId.Hub => CreateHubMenu(),
                    FullScreenWindowId.Settings => CreateSettingsMenu(),
                    FullScreenWindowId.Levels => CreateLevelsMenu(),
                    _ => null,
                };
            }
        }

        private WindowBase CreateLevelsMenu()
        {
            WindowConfig config = _staticData.ForWindow(FullScreenWindowId.Levels);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }

        private WindowBase CreateSettingsMenu()
        {
            WindowConfig config = _staticData.ForWindow(FullScreenWindowId.Settings);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }

        public GameWindowBase InstantiateWindow(GameWindowId windowID)
        {
            var window = CreateSpecificWindow(windowID);
            window.transform.SetAsFirstSibling();
            window.gameObject.SetActive(false);
            return window;

            GameWindowBase CreateSpecificWindow(GameWindowId windowId)
            {
                return windowId switch
                {
                    GameWindowId.InGameHUD => CreateInGameHUD(),
                    GameWindowId.PlayerDead => CreatePlayerDeadWindow(),
                    GameWindowId.InGamePauseMenu => CreatePauseMenu(),
                    GameWindowId.EndGame => CreateEndGame(),
                    GameWindowId.BeforeGameHUD => CreateBeforeGameHUD(),
                    _ => null,
                };
            }
        }

        private GameWindowBase CreateBeforeGameHUD()
        {
            GameWindowConfig config = _staticData.ForGameWindow(GameWindowId.BeforeGameHUD);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }

        private GameWindowBase CreatePauseMenu()
        {
            GameWindowConfig config = _staticData.ForGameWindow(GameWindowId.InGamePauseMenu);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }

        private GameWindowBase CreatePlayerDeadWindow()
        {
            GameWindowConfig config = _staticData.ForGameWindow(GameWindowId.PlayerDead);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }


        private GameWindowBase CreateInGameHUD()
        {
            GameWindowConfig config = _staticData.ForGameWindow(GameWindowId.InGameHUD);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }
        
        public List<LevelSelectButton> InstantiateLevelButtons(int totalLevels, Transform parent)
        {
            List<LevelSelectButton> buttons = new();
            
            LevelSelectButton tutorialButton = _assets.Instantiate<LevelSelectButton>(AssetPath.LevelSelectButton, parent);
            tutorialButton.Construct();
            buttons.Add(tutorialButton);
            
            for (int i = 1; i < totalLevels + 1; i++)
            {
                LevelSelectButton button = _assets.Instantiate<LevelSelectButton>(AssetPath.LevelSelectButton, parent);
                button.Construct(i);
                buttons.Add(button);
            }

            return buttons;
        }

        public List<Image> CreateTutorialImages(Sprite[] messageSprites, Transform parent)
        {
            List<Image> tutorialImages = new();
            foreach (Sprite sprite in messageSprites)
            {
                Image tutorialImageInstance = _assets.Instantiate<Image>(AssetPath.TutorialImagePath, parent);
                tutorialImageInstance.sprite = sprite;
                tutorialImages.Add(tutorialImageInstance);
            }
            return tutorialImages;
        }
        
        private GameWindowBase CreateEndGame()
        {
            GameWindowConfig config = _staticData.ForGameWindow(GameWindowId.EndGame);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }

        private WindowBase CreateHubMenu()
        {
            WindowConfig config = _staticData.ForWindow(FullScreenWindowId.Hub);
            var window = Object.Instantiate(config.Prefab, _uiRoot);
            return window;
        }
    }
}