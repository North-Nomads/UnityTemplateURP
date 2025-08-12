using _Project.MVVM;
using UnityEngine;

namespace _Project.UI.Views
{
    public abstract class View: MonoBehaviour 
    {
        public IViewModel ViewModel { get; set; }

        public void SetViewModel(IViewModel viewModel)
        {
            ViewModel = viewModel;
        }


        public virtual void OnShow() { gameObject.SetActive(true); }
        public virtual void OnHide() { gameObject.SetActive(false); }
        public virtual void OnClose() { Destroy(gameObject); }
    }
}