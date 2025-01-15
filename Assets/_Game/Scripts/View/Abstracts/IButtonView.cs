using System;
using UnityEngine;

namespace _Game.Scripts.View.Abstracts
{
    public interface IButtonView
    {
        public event Action ClickedButton;
        public void Init(Sprite icon, string nameButton);
        public void OnValueChanged(string value);
        public void OnPriceChanged(string price);
        public void SetInteractable(bool canAfford, bool isInteractableChangeFactor);
    }
}