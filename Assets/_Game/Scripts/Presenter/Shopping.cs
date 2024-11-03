using System;
using R3;

public class Shopping: IDisposable
{
    private readonly ICurrencyProvider _currencyProvider;
    private readonly CompositeDisposable _disposable = new();
    private readonly IClickCalculator _clickCalculator; 
    private readonly ButtonsManager _buttonsManager;
    
    public Shopping(ICurrencyProvider currencyProvider,ICoinsView coinsView,IClickCalculator clickCalculator,ButtonsManager buttonsManager)
    {
        _currencyProvider= currencyProvider;
        _clickCalculator= clickCalculator;
        _buttonsManager= buttonsManager;
        
        _clickCalculator.ClickCalculated += AddCoins;
        _buttonsManager.AutoClickService.OnAddCoinsAuto += AddCoinsAuto;
        _buttonsManager.MainButtons.ForEach(buttonMain=>buttonMain.ClickedButtonMain += Purchase);
        _currencyProvider.CurrentBalance.Subscribe(value=> coinsView.SetCoinsText(FormatLargeNumber.ModificationInt(value))).AddTo(_disposable);
    }
    
    private bool Purchase(int price) 
        => _currencyProvider.CurrentBalance.CurrentValue >= price && _currencyProvider.TryRemoveCoins(price);

    private void AddCoins(int currentClick) 
        => _currencyProvider.TryAddCoins(currentClick);

    private void AddCoinsAuto(int valueClickSec,int valueFactorClickSec) 
        => _currencyProvider.TryAddCoins(valueClickSec*valueFactorClickSec);

    public void Dispose()
    {
        _clickCalculator.ClickCalculated -= AddCoins;
        _buttonsManager.AutoClickService.OnAddCoinsAuto -= AddCoinsAuto;
        _buttonsManager.MainButtons.ForEach(buttonMain=>buttonMain.ClickedButtonMain -= Purchase);
        _disposable.Dispose();
    }
}
