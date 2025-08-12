using System.Reflection;
using _Project.UI.Views;
using R3;
using TMPro;
using UnityEngine;

namespace _Project.UI.Binders
{
    [RequireComponent(typeof(View))]
    public class TextBinderR3 : MonoBehaviour
    {
        public string PropertyName; // name of the ReactiveProperty<T> in ViewModel
        public TextMeshProUGUI TargetText; // assign in inspector

        private View _view;
        private System.IDisposable _subscription;

        void Awake()
        {
            _view = GetComponent<View>();
        }

        void OnEnable()
        {
            Bind();
        }

        void OnDisable()
        {
            _subscription?.Dispose();
            _subscription = null;
        }

        private void Bind()
        {
            _subscription?.Dispose();

            var vm = _view.ViewModel;
            if (vm == null || string.IsNullOrEmpty(PropertyName) || TargetText == null) return;

            var vmType = vm.GetType();
            var prop = vmType.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance);
            if (prop == null)
            {
                Debug.LogWarning($"TextBinderR3: property '{PropertyName}' not found on {vmType.Name}");
                return;
            }

            var reactiveProp = prop.GetValue(vm);
            if (reactiveProp == null)
            {
                Debug.LogWarning($"TextBinderR3: property '{PropertyName}' is null on {vmType.Name}");
                return;
            }

            // R3's ReactiveProperty<T> has a .Subscribe(Action<T>)
            var propType = reactiveProp.GetType();
            if (!propType.IsGenericType || propType.GetGenericTypeDefinition() != typeof(ReactiveProperty<>))
            {
                Debug.LogWarning($"TextBinderR3: '{PropertyName}' is not a ReactiveProperty<T>");
                return;
            }

            var genericArg = propType.GetGenericArguments()[0];
            var subscribeMethod =
                propType.GetMethod("Subscribe", new[] { typeof(System.Action<>).MakeGenericType(genericArg) });

            // Create Action<T> delegate that updates the text
            var updateMethod = GetType().GetMethod(nameof(UpdateText), BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(genericArg);

            var actionDelegate = System.Delegate.CreateDelegate(typeof(System.Action<>).MakeGenericType(genericArg),
                this, updateMethod);

            // Call Subscribe(action)
            _subscription = (System.IDisposable)subscribeMethod.Invoke(reactiveProp, new object[] { actionDelegate });

            // Set initial text from .Value
            var valueProp = propType.GetProperty("Value");
            var initialValue = valueProp.GetValue(reactiveProp);
            TargetText.text = initialValue?.ToString() ?? "";
        }

        private void UpdateText<T>(T newValue)
        {
            if (TargetText != null)
                TargetText.text = newValue?.ToString() ?? "";
        }
    }
}