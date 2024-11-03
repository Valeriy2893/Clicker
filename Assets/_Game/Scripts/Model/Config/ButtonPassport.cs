using UnityEngine;

[CreateAssetMenu(fileName = "NewButtonPassport", menuName = "Game/ButtonPassport")]
public class ButtonPassport : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public int Order { get; private set; }
    [field: SerializeField] public TypeButton TypeButton { get; private set; }
    [field:Range(0, 1000)][field: SerializeField] public int DefaultValue{ get; private set; }
    [field:Range(1, 1000000)][field: SerializeField] public int DefaultPrice{ get; private set; } 
    [field:Range(1.1f, 1000)][field: SerializeField] public float FactorPrice{ get; private set; }
    
    private void OnValidate()
    {
        if (TypeButton != TypeButton.ClickSec && DefaultValue<1)
            DefaultValue = 1;
        
        if (TypeButton == TypeButton.ChanceFactorClick && DefaultValue>100)
            DefaultValue = 100;
    }
}
public enum TypeButton
{
    Click,
    ClickSec,
    FactorClick,
    ChanceFactorClick,
    FactorClickSec
}
