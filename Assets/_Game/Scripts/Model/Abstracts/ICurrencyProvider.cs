using R3;

namespace _Game.Scripts.Model.Abstracts
{
    public interface ICurrencyProvider
    {
        public ReadOnlyReactiveProperty<int> CurrentBalance { get; }
        public bool TryRemoveCoins(int amount);
        public bool TryAddCoins(int count);
    }
}