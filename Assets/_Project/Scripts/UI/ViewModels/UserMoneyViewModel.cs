using System;
using _Project.Models;
using _Project.MVVM;
using R3;
using UnityEngine;

namespace _Project.UI.ViewModels
{
    public class UserMoneyViewModel : IViewModel
    {
        private readonly UserModel _model;

        // Observables for the view to subscribe
        public ReactiveProperty<int> Money { get; } = new (300);

        public UserMoneyViewModel(UserModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            Money.Value = _model.Money;
        }

        // Commands (methods) that View binders can call
        public void AddOne()
        {
            _model.Add(1);
            Money.Value = _model.Money;
        }

        public void RemoveOne()
        {
            _model.Remove(1);
            Money.Value = _model.Money;
        }
    }
}