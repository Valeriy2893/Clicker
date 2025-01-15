using UnityEngine;

namespace _Game.Scripts.View.Abstracts
{
    public interface IAnimalView
    {
        public GameObject GameObjectAnimal { get; }
        public void PlayAnimation(string nameCurrentAnimation);
    }
}