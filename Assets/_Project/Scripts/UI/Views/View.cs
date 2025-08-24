using _Project.MVVM;
using UnityEngine;

namespace _Project.UI.Views
{
    public abstract class View : MonoBehaviour
    {
        public virtual void OnShow()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnHide()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnClose()
        {
            Destroy(gameObject);
        }
    }
}