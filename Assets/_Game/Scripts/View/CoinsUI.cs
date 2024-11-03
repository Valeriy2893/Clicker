using TMPro;
using UnityEngine;

public class CoinsUI: MonoBehaviour,ICoinsView
{
    [SerializeField] private TMP_Text _coins;
    public void SetCoinsText(string levelText) => _coins.text = levelText;
}
