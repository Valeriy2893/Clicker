using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Model.Config;
using R3;
using UnityEngine;

namespace _Game.Scripts.Model
{
    public class ButtonInfo : IButtonInfo
    {
        private readonly ReactiveProperty<int> _value = new();
        private readonly ReactiveProperty<int> _price = new();
        private readonly int _defaultValue;
        private readonly int _defaultPrice;
        private readonly float _factorPrice;
        
        public TypeButton TypeButton { get; }
        public ReadOnlyReactiveProperty<int> Value => _value;
        public ReadOnlyReactiveProperty<int> Price => _price;

        public ButtonInfo(TypeButton typeButton, int value, int price, float factorPrice)
        {
            TypeButton = typeButton;
            _defaultValue = value;
            _defaultPrice = price;
            _factorPrice = factorPrice;

            _value.Value = value;
            _price.Value = price;
        }

        public void IncreaseValue()
        {
            if (!CanIncreaseValue()) return;

            _value.Value++;
            UpdatePrice();
        }

        public bool CanIncreaseValue()
            => _factorPrice > 0 && _defaultPrice > 0 && _defaultValue >= 0 && _price.Value > 0;

        private void UpdatePrice()
            => _price.Value = Mathf.CeilToInt(_factorPrice * _price.Value);
    }
}