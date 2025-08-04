using System;
using System.Reflection;
using _Project.MVVM;

namespace _Project.Scripts.MVVM.Binders
{
    public class EmptyMethodBinder : MethodBinder
    {
        private event Action _action;

        private string MethodName => PropertyName;
        
        protected override IDisposable BindInternal(IViewModel viewModel)
        {
            _action = (Action)Delegate.CreateDelegate(typeof(Action), viewModel, MethodName);
            return null;
        }

        public void Perform()
        {
            _action?.Invoke();
        }
    }
}