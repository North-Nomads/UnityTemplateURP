using _Project.UI.Services.Windows;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Project.UI.Elements
{
    public class OpenWindowButton : MonoBehaviour
    {
        [FormerlySerializedAs("fullScreenWindowId")] [FormerlySerializedAs("windowId")] [SerializeField] private HubWindowId hubWindowId;
        private Button _button;
        private IWindowContainer _windowContainer;

        public void Construct(IWindowContainer windowContainer) 
            => _windowContainer = windowContainer;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Open);
        }

        private void Open() 
            => _windowContainer.Open(hubWindowId);
    }
}