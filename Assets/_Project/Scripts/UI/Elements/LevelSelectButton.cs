using System;
using _Project.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    [RequireComponent(typeof(Button))]
    public class LevelSelectButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        
        private Button _button;
        private int _levelIndex;
        public event EventHandler<int> LevelButtonPressed = delegate { };

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => LevelButtonPressed(this, _levelIndex));
        }

        public void Construct(int levelIndex)
        {
            if (levelIndex == Constants.TutorialLevelIndex)
                Debug.LogError("Trying to construct level button with index = tutorial index. Tutorial must be called without parameters");
            _levelIndex = levelIndex;
            buttonText.text = _levelIndex.ToString();
        }

        public void Construct()
        {
            _levelIndex = 0;
            buttonText.text = "Tutorial";
        }
    }
}
