using System;
using System.Reflection;
using _Project.MVVM;
using ObservableCollections;
using R3;
using Binder = _Project.MVVM.Binder;

namespace _Project.MVVM.Binders
{
    public abstract class ObservableBinder : Binder
    {
    }
    
    public abstract class ObservableBinder<T> : ObservableBinder
    {
        protected IDisposable BindObservable(string propertyName, IViewModel viewModel, Action<T> callback)
        {
            PropertyInfo propertyInfo = viewModel.GetType().GetProperty(propertyName);
            IObservable<T> observable = (IObservable<T>)propertyInfo.GetValue(viewModel, null);
            IDisposable subscription = observable.Subscribe(callback); // обещал что-то импортировать и будет работать
            return subscription;
        }

        protected IDisposable BindCollection(string propertyName, IViewModel viewModel,
            Observer<CollectionAddEvent<T>> addedCallback, Observer<CollectionRemoveEvent<T>> removedCallback)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var reactiveCollection = (IObservableCollection<T>)propertyInfo.GetValue(viewModel);

            var addedSubscription = reactiveCollection.ObserveAdd().Subscribe(addedCallback);
            var removedSubscription = reactiveCollection.ObserveRemove().Subscribe(removedCallback);
            var compositeDisposable = new CompositeDisposable();

            compositeDisposable.Add(addedSubscription);
            compositeDisposable.Add(removedSubscription);

            return compositeDisposable;
        }

    }
}