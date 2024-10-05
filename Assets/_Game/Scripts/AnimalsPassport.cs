using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimalPassport", menuName = "Game/AnimalsPassport")]
public class AnimalsPassport : ScriptableObject
{
    [field: SerializeField] public GameObject Skin { get; private set; }

}
