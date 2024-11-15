using _Game.Scripts.Model.Config;
using R3;

namespace _Game.Scripts.Model.Abstracts
{
    public interface IButtonInfo
    {
        public TypeButton TypeButton { get; }
        public ReadOnlyReactiveProperty<int> Value { get; }
        public ReadOnlyReactiveProperty<int> Price { get; }
        public void AddValue();
        public bool CanAddValue();
    }
}