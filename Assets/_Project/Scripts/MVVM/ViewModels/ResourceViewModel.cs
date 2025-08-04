using R3;
using UnityEngine;

namespace _Project.MVVM.ViewModels
{
    public class ResourceViewModel : IViewModel
    {
        private ReactiveProperty<int> Amount;
        private ReactiveProperty<Sprite> Icon;
    }
}