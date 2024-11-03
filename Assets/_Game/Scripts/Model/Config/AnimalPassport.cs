using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimalPassport", menuName = "Game/AnimalsPassport")]
public class AnimalPassport : ScriptableObject
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public List<AnimationAnimal> AnimationAnimals { get; private set; }
}
[Serializable]
public class AnimationAnimal
{
    [field: SerializeField] public NameAnimanion NameAnimanion { get;  set; }
    [field: SerializeField] public AnimationClip AnimationClip { get; private set; }
}
public enum NameAnimanion
{
    Idle,
    Death,
    Fly,
    Jump,
    Run
}

