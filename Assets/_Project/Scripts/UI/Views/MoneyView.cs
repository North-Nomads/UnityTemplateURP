using System;
using _Project.UI.ViewModels;
using R3;
using Reflex.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Views
{
    public class MoneyView : View
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button buttonAdd;
        [SerializeField] private Button buttonRemove;

        private UserMoneyViewModel _viewModel;

        private void Awake()
        {
            buttonAdd.onClick.AddListener(AddMoney);
            buttonRemove.onClick.AddListener(RemoveMoney);
        }

        private void RemoveMoney()
        {
            _viewModel.RemoveOne();
        }

        private void AddMoney()
        {
            _viewModel.AddOne();
        }
        
        

        [Inject]
        public void Construct(UserMoneyViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Money.Subscribe(onNext =>
            {
                text.text = onNext.ToString();
            });
        }
    }
}