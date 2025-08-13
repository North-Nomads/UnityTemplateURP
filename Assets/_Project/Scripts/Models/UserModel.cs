using R3;
using UnityEngine;

namespace _Project.Models
{
    public class UserModel
    {
        public ReadOnlyReactiveProperty<int> Money => _money;
        private readonly ReactiveProperty<int> _money = new(10);

        public void Add(int amount)
        {
            _money.Value += amount;
            Debug.Log(_money.Value);
        }

        public void Remove(int amount)
        {
            _money.Value -= amount;
            Debug.Log(_money.Value);
        }
    }
}