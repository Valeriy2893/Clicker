using System;
using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Model.Config;
using _Game.Scripts.Services;
using _Game.Scripts.Services.Abstract;
using _Game.Scripts.View.Abstracts;
using R3;

namespace _Game.Scripts.Presenter
{
    public class VolumeMain: IDisposable
    {
        private readonly IVolume _volume;
        private readonly IVolumeView _volumeUI;
        private readonly CompositeDisposable _disposable = new();
        private readonly IClickHandler _clickHandler;
    
        public VolumeMain(IVolume volume,IVolumeView volumeUI,ILevelProgression levelProgression,IClickHandler clickHandler,ResourcesManager resourcesManager)
        {
            _volume=volume;
            _volumeUI = volumeUI;
            _clickHandler = clickHandler;
            _clickHandler.ClickedAnimal += PlayClick;
        
            _volumeUI.Init(resourcesManager.GetSpriteVolume(IconType.Off), resourcesManager.GetSpriteVolume(IconType.On),
                resourcesManager.GetAudioClipVolume(AudioType.Click),resourcesManager.GetAudioClipVolume(AudioType.Change),
                resourcesManager.GetAudioClipVolume(AudioType.Background));
        
            _volume.CurrentVolume
                .Subscribe(value=> volumeUI.SetVolumeIcon(value>0)).AddTo(_disposable);
        
            _volumeUI.OnClickButtonVolume+=_volume.VolumeControl;
        
            levelProgression.CurrentLevel.Skip(1)
                .Subscribe(x=>_volumeUI.PlayChangeSkin()).AddTo(_disposable);
        }

        private void PlayClick() => _volumeUI.PlayClick();

        public void Dispose()
        {
            _clickHandler.ClickedAnimal -= PlayClick;
            _volumeUI.OnClickButtonVolume-=_volume.VolumeControl;
            _disposable.Dispose();
        }
    }
}
