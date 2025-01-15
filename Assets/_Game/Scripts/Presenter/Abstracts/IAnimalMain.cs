using System;
using UnityEngine;

namespace _Game.Scripts.Presenter.Abstracts
{
    public interface IAnimalMain : IDisposable
    {
        public int Index { get; }
        public GameObject GameObjectAnimal { get; }
        public void ClickTracking();
    }
}