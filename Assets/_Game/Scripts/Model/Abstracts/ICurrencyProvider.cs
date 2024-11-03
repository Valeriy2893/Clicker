using R3;

public interface ICurrencyProvider
{
    public ReadOnlyReactiveProperty<int> CurrentBalance { get; }
    public bool TryRemoveCoins(int amount);
    public bool TryAddCoins(int count);
}