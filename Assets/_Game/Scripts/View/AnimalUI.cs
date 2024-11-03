using System.Collections.Generic;
using UnityEngine;

public class AnimalUI: MonoBehaviour, IAnimalView
{
    [SerializeField] private Animator _animator;
    public GameObject GameObjectAnimal => gameObject;
    public void PlayAnimation(string nameCurrentAnimation)
    {
        if (nameCurrentAnimation == null) return;

        var normalizedTime = 0.0f;
        var layer = -1;
        
        _animator.Play(nameCurrentAnimation, layer, normalizedTime);
    }
}