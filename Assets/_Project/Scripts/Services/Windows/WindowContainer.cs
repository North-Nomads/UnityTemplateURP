using System;
using System.Collections.Generic;
using _Project.UI.Services.Factory;
using _Project.UI.Views;

namespace _Project.UI.Services.Windows
{
    public class WindowContainer : IWindowContainer
    {
        private readonly IUIFactory _uiFactory;
        private readonly Dictionary<Type, View> _windows = new();

        public WindowContainer(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public TView Open<TView>() where TView : View
        {
            var type = typeof(TView);

            if (_windows.TryGetValue(type, out var existing))
            {
                existing.OnShow();
                return (TView)existing;
            }

            TView view = _uiFactory.CreateViewWithInjection<TView>();
            _windows[type] = view;
            view.OnShow();
            return view;
        }

        public void Close<TView>() where TView : View
        {
            var type = typeof(TView);
            if (_windows.TryGetValue(type, out var view))
            {
                view.OnClose();
                _windows.Remove(type);
            }
        }
    }
}