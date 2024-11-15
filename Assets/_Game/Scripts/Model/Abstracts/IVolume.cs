using R3;

namespace _Game.Scripts.Model.Abstracts
{
    public interface IVolume
    {
        public ReadOnlyReactiveProperty<int> CurrentVolume { get; }
        public void VolumeControl();
    }
}