using _Game.Scripts.View.Abstracts;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.View
{
    public class CoinsUI: MonoBehaviour,ICoinsView
    {
        [SerializeField] private TMP_Text _coins;
        public void SetCoinsText(string levelText) => _coins.text = levelText;
    }
}
