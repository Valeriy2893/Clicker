using R3;

public class Wallet
{
    public ReadOnlyReactiveProperty<int> AllCoins => _allCoins;
    private readonly ReactiveProperty<int> _allCoins=new();
    
    public bool TryRemoveCoins(int amount)
    {
        if (_allCoins.Value >= amount)
        {
            _allCoins.Value -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void AddCoins()
    {
        _allCoins.Value ++;
    }
}
