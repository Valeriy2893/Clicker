using _Game.Scripts.Model.Abstracts;
using R3;
using UnityEngine;

namespace _Game.Scripts.Model
{
    public class VolumeInfo: IVolume
    {
        public ReadOnlyReactiveProperty<int> CurrentVolume=> _currentVolume;
        private readonly ReactiveProperty<int> _currentVolume=new();
    
        private const int EnableVolume = 1;
        private const int DisableVolume = 0;

        public VolumeInfo()
        {
            SetCurrentVolume();
        }
        public void VolumeControl()
        {
            SetCurrentVolume();
            _currentVolume.Value = _currentVolume.Value == EnableVolume ? DisableVolume : EnableVolume;
            AudioListener.volume = _currentVolume.Value;
        }
        private void SetCurrentVolume() => _currentVolume.Value = (int)AudioListener.volume;
    }
}