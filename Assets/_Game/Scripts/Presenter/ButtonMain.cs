using System;
using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter.Abstracts;
using _Game.Scripts.Services;
using _Game.Scripts.View.Abstracts;
using R3;

namespace _Game.Scripts.Presenter
{
    public class ButtonMain : IButtonMain, IDisposable
    {
        public ReadOnlyReactiveProperty<int> Value => _buttonInfo.Value;
        public TypeButton TypeButton => _buttonInfo.TypeButton;

        private readonly IButtonInfo _buttonInfo;
        private readonly IButtonView _buttonUI;
        private readonly Shopping _shopping;

        private readonly CompositeDisposable _disposable = new();
        private const int MaxValueChanceFactorClick = 100;
        public event Func<int, bool> ClickedButtonMain;

        public ButtonMain(IButtonInfo buttonInfo, IButtonView buttonUI, ICurrencyProvider currencyProvider)
        {
            _buttonInfo = buttonInfo;
            _buttonUI = buttonUI;

            _buttonUI.OnClickButton += ClickButtonMain;

            buttonInfo.Value.Subscribe(value => buttonUI.OnValueChanged(FormatLargeNumber.ModificationInt(value)))
                .AddTo(_disposable);
            buttonInfo.Price.Subscribe(price => buttonUI.OnPriceChanged(FormatLargeNumber.ModificationInt(price)))
                .AddTo(_disposable);

            currencyProvider.CurrentBalance.Subscribe(allCoins
                    => buttonUI.SetInteractable(allCoins >= buttonInfo.Price.CurrentValue,
                        IsInteractableChangeFactor()))
                .AddTo(_disposable);
        }

        private void ClickButtonMain()
        {
            if (!_buttonInfo.CanAddValue() || ClickedButtonMain == null) return;

            if (ClickedButtonMain.Invoke(_buttonInfo.Price.CurrentValue))
                _buttonInfo.AddValue();
        }

        public void Dispose()
        {
            _buttonUI.OnClickButton -= ClickButtonMain;
            _disposable.Dispose();
        }

        private bool IsInteractableChangeFactor()
            => TypeButton != TypeButton.ChanceFactorClick || _buttonInfo.Value.CurrentValue < MaxValueChanceFactorClick;
    }
}


