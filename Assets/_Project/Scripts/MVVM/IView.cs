using System;
using UnityEngine;

namespace _Project.MVVM
{
    public interface IView
    {
        Type ViewModelType { get; }
        GameObject gameObject { get; }
    }
}