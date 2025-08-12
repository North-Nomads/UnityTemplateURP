using System.Reflection;
using _Project.UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Binders
{
    public class ButtonMethodBinder : MonoBehaviour
    {
        public string MethodName; // method on VM with signature: void Method()
        public Button TargetButton;

        private View _view;
        private MethodInfo _cachedMethod;
        private object _vmCached;

        void Awake() => _view = GetComponent<View>();

        void OnEnable()
        {
            TryBind();
        }

        void OnDisable()
        {
            if (TargetButton != null) TargetButton.onClick.RemoveListener(OnClicked);
        }

        void TryBind()
        {
            if (_view == null) _view = GetComponent<View>();
            if (_view.ViewModel == null || TargetButton == null || string.IsNullOrEmpty(MethodName)) return;

            var vm = _view.ViewModel;
            var m = vm.GetType().GetMethod(MethodName, BindingFlags.Public | BindingFlags.Instance);
            if (m == null)
            {
                Debug.LogWarning($"ButtonMethodBinder: method '{MethodName}' not found on VM {vm.GetType().Name}");
                return;
            }

            _cachedMethod = m;
            _vmCached = vm;

            TargetButton.onClick.AddListener(OnClicked);
        }

        void OnClicked()
        {
            if (_cachedMethod == null || _vmCached == null) return;
            _cachedMethod.Invoke(_vmCached, new object[0]);
        }
    }
}