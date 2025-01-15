using _Game.Scripts.Model.Abstracts;
using R3;

namespace _Game.Scripts.Model
{
    public class Wallet : ICurrencyProvider
    {
        private readonly ReactiveProperty<int> _allCoins = new();
        
        public ReadOnlyReactiveProperty<int> CurrentBalance => _allCoins;

        public bool TryRemoveCoins(int count)
        {
            if (count <= 0 || _allCoins.Value < count) return false;

            _allCoins.Value -= count;

            return true;
        }

        public bool TryAddCoins(int count)
        {
            if (count <= 0 || _allCoins.Value >= int.MaxValue) return false;

            if (_allCoins.Value >= int.MaxValue - count)
                _allCoins.Value = int.MaxValue;
            else
                _allCoins.Value += count;

            return true;
        }
    }
}