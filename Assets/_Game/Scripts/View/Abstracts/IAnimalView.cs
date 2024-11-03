using UnityEngine;

public interface IAnimalView
{
    public void PlayAnimation(string nameCurrentAnimation);
    public GameObject GameObjectAnimal { get; }
}