using UnityEngine;

namespace _Game.Scripts.View.Abstracts
{
    public interface IAnimalView
    {
        public void PlayAnimation(string nameCurrentAnimation);
        public GameObject GameObjectAnimal { get; }
    }
}