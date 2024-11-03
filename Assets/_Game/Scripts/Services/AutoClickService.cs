using System;
using R3;

public class AutoClickService : IDisposable
{
    private readonly CompositeDisposable _disposable = new();
    public event Action<int, int> OnAddCoinsAuto;

    public void Initialize(ButtonMain clickSecButton, ButtonMain factorClickSecButton)
    {
        clickSecButton.Value
            .Where(value => value > 0)
            .Take(1)
            .Subscribe(_ 
                => StartAutoClick(clickSecButton, factorClickSecButton))
            .AddTo(_disposable);
    }

    private void StartAutoClick(ButtonMain clickSecButton, ButtonMain factorClickSecButton)
    {
        Observable.Interval(TimeSpan.FromSeconds(1))
            .Subscribe(_ => OnAddCoinsAuto?.Invoke(clickSecButton.Value.CurrentValue, factorClickSecButton.Value.CurrentValue))
            .AddTo(_disposable);
    }

    public void Dispose()=> _disposable.Dispose();
}


        
