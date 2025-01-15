using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Model.Config
{
    [CreateAssetMenu(fileName = "NewAnimalPassport", menuName = "Game/AnimalsPassport")]
    public class AnimalPassport : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public List<AnimationClip> AnimationAnimals { get; private set; }
    }
}