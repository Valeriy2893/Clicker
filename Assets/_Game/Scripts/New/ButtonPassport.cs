using UnityEngine;

[CreateAssetMenu(fileName = "NewButtonForShopPassport", menuName = "Game/ButtonForShopPassport")]
public class ButtonPassport : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public int Order { get; private set; }
    [field: SerializeField] public TypeButton TypeButton { get; private set; }
    [field: SerializeField] public int DefaultValue{ get; private set; }
    [field: SerializeField] public int DefaultPrice{ get; private set; }
    [field: SerializeField] public int FactorPrice{ get; private set; }
}
public enum TypeButton
{
    Click,
    ClickSec,
    FactorClick,
    ChanceFactorClick,
    FactorClickSec
}
