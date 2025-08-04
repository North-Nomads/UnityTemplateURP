using System;
using UnityEngine;

namespace _Project.MVVM
{
    public abstract class Binder : MonoBehaviour
    {
        [SerializeField] private string viewModelTypeFullName;
        [SerializeField] private string propertyName;

        public string PropertyName => propertyName;

        private IDisposable _binding;

        private void OnDestroy()
        {
            _binding?.Dispose();
        }

        public void Bind(IViewModel viewModel)
        {
            var receivedViewModelTypeFullName = viewModel.GetType().FullName;
            if (receivedViewModelTypeFullName == viewModelTypeFullName)
            {
                _binding = BindInternal(viewModel);
            }
        }

        protected abstract IDisposable BindInternal(IViewModel viewModel);
    }
}