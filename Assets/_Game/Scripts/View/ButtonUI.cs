using System;
using _Game.Scripts.View.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.View
{
    public class ButtonUI : MonoBehaviour, IButtonView
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private Button _clickButton;

        public event Action ClickedButton;

        public void Init(Sprite icon, string nameButton)
        {
            _icon.sprite = icon;
            _name.text = nameButton;
            _clickButton.onClick.AddListener(() => ClickedButton?.Invoke());
        }

        public void OnValueChanged(string value) => _count.text = value;
        
        public void OnPriceChanged(string price) => _price.text = price;

        public void SetInteractable(bool canAfford, bool isInteractableChangeFactor)
        {
            _clickButton.interactable = canAfford;

            if (isInteractableChangeFactor) return;
            _clickButton.interactable = false;
            _count.gameObject.SetActive(false);
            _price.gameObject.SetActive(false);
        }

        private void OnDisable()
            => _clickButton.onClick.RemoveAllListeners();
    }
}