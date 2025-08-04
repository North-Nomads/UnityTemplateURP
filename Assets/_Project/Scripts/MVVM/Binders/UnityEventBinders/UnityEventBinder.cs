using System;
using UnityEngine.Events;

namespace _Project.MVVM.Binders.UnityEventBinders
{
    public class UnityEventBinder<T> : ObservableBinder<T>
    {
        private UnityEvent<T> _event;
        
        protected override IDisposable BindInternal(IViewModel viewModel) 
            => BindObservable(PropertyName, viewModel, OnPropertyChanged);

        private void OnPropertyChanged(T newValue) 
            => _event?.Invoke(newValue);
    }
}