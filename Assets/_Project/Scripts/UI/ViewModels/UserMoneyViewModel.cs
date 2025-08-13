using System;
using _Project.Models;
using _Project.MVVM;
using R3;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.UI.ViewModels
{
    public class UserMoneyViewModel : IViewModel
    {
        private readonly UserModel _model;

        public ReadOnlyReactiveProperty<int> Money => _money;
        private readonly ReactiveProperty<int> _money = new(300);

        public UserMoneyViewModel(UserModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _model.Money.Subscribe(onNext => _money.Value = onNext);
        }

        // Commands (methods) that View binders can call
        public void AddOne()
        {
            _model.Add(1);
        }

        public void RemoveOne()
        {
            _model.Remove(1);
        }
    }
}