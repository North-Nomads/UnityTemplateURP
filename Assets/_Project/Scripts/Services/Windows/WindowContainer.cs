using System;
using System.Collections.Generic;
using _Project.MVVM;
using _Project.StaticData;
using _Project.UI.Services.Factory;
using _Project.UI.Views;
using UnityEngine;

namespace _Project.UI.Services.Windows
{
    public class WindowContainer : IWindowContainer
    {
        private readonly Dictionary<Type, View> _windows = new();
        private readonly IStaticData _staticData;
        private readonly UIFactory _factory;


        public WindowContainer(IStaticData staticData, UIFactory factory)
        {
            _staticData = staticData;
            _factory = factory;
        }
        
        public TView Open<TView>(GameObject prefab) where TView : View
        {
            throw new NotImplementedException();
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