using System;
using _Project.MVVM;

namespace _Project.Scripts.MVVM.Binders
{
    public abstract class GenericMethodBinder : MethodBinder
    {
        
    }
    
    public class GenericMethodBinder<T> : GenericMethodBinder
    {
        private Action<T> _action;
        
        protected override IDisposable BindInternal(IViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}