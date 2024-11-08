using System;
using R3;

public class ButtonMain: IDisposable
{
    public ReadOnlyReactiveProperty<int> Value => _buttonInfo.Value;
    public TypeButton TypeButton => _buttonInfo.TypeButton;

    private readonly IButtonInfo _buttonInfo;
    private readonly IButtonView _buttonUI;
    private readonly Shopping _shopping;
    
    private readonly CompositeDisposable _disposable = new();
    public event Func<int,bool> ClickedButtonMain;
    
    public ButtonMain(IButtonInfo buttonInfo, IButtonView buttonUI,ICurrencyProvider currencyProvider)
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
            buttonInfo.TypeButton, buttonInfo.Value.CurrentValue))
            .AddTo(_disposable);
    }

    private void ClickButtonMain()
    {
        if (!_buttonInfo.CanAddValue() || ClickedButtonMain == null ) return;
        
        if (ClickedButtonMain.Invoke(_buttonInfo.Price.CurrentValue))
            _buttonInfo.AddValue();
    }
    
    public void Dispose()
    {
        _buttonUI.OnClickButton -= ClickButtonMain;
        _disposable.Dispose();
    }
}



