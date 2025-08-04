using System;
using _Project.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.GameWindows
{
    public class InGameHUD : GameWindowBase
    {
        [SerializeField] private TextMeshProUGUI nextWaveTimer;
        [SerializeField] private TextMeshProUGUI playerWallet;
        [SerializeField] private Transform buildingCardParent;
        [SerializeField] private Transform timerParentObject;
        [SerializeField] private Button timerSkipButton;
        [SerializeField] private Button collapseButton;
        [SerializeField] private Button[] openCollapsedButtons;
        [SerializeField] private Transform collapsedParent;
        [SerializeField] private Transform openedParent;
        [SerializeField] private TutorialInGameHUD[] hudParents;
        
        private float _delayTimeLeft;

        public event EventHandler NextWaveTimerIsUp = delegate { };

        protected override void OnStart()
        {
            base.OnStart();
            timerSkipButton.onClick.AddListener(HandlePreparationTimeSkip);
            collapseButton.onClick.AddListener(() => ToggleBuildingHUD(true));
            foreach (Button openCollapsedButton in openCollapsedButtons)
                openCollapsedButton.onClick.AddListener(() => ToggleBuildingHUD(false));
        }

        public void HideAllHUD()
        {
            foreach (TutorialInGameHUD tutorialInGameHUD in hudParents)
                tutorialInGameHUD.ParentObject.gameObject.SetActive(false);
        }

        public void EnableHUDPart(InGameHUDOptions option)
        {
            if (option == InGameHUDOptions.None)
                return;
            
            foreach (TutorialInGameHUD tutorialInGameHUD in hudParents)
                if (tutorialInGameHUD.Option == option)
                    tutorialInGameHUD.ParentObject.gameObject.SetActive(true);
        }

        private void ToggleBuildingHUD(bool isCollapsed)
        {
            collapsedParent.gameObject.SetActive(isCollapsed);
            openedParent.gameObject.SetActive(!isCollapsed);
        }

        private void HandlePreparationTimeSkip()
        {
            _delayTimeLeft = Constants.TimeLeftAfterPreparationTimeSkip;
            timerSkipButton.gameObject.SetActive(false);
        }

        public override void OnOpened()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(buildingCardParent.GetComponent<RectTransform>());
        }

        public void SetNextWaveTimer(float seconds)
        {
            _delayTimeLeft = seconds;
            nextWaveTimer.gameObject.SetActive(true);
            timerSkipButton.gameObject.SetActive(true);
            timerParentObject.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (_delayTimeLeft <= 0)
                return;
            
            _delayTimeLeft -= Time.deltaTime;
            if (_delayTimeLeft <= Constants.TimeLeftAfterPreparationTimeSkip && nextWaveTimer.gameObject.activeSelf)
            {
                timerSkipButton.gameObject.SetActive(false);
            }
            if (_delayTimeLeft < 0)
            {
                _delayTimeLeft = 0;
                NextWaveTimerIsUp(null, null);
                nextWaveTimer.gameObject.SetActive(false);
                timerParentObject.gameObject.SetActive(false);
            }

            UpdateTimerDisplay();
        }

        private void UpdateTimerDisplay()
        {
            int seconds = Mathf.FloorToInt(_delayTimeLeft % 60f);
            nextWaveTimer.text = $"{seconds + 1:00}";
        }
    }

    [Serializable]
    public class TutorialInGameHUD
    {
        [SerializeField] private InGameHUDOptions option;
        [SerializeField] private Transform parentObject;

        public InGameHUDOptions Option => option;
        public Transform ParentObject => parentObject;
    }

    public enum InGameHUDOptions
    {
        None,
        Currency,
        Timer,
        HUD
    }
}