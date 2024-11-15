using System;
using UnityEngine;

namespace _Game.Scripts.View.Abstracts
{
    public interface IVolumeView
    {
        public void Init(Sprite spriteOff, Sprite spriteOn, AudioClip audioClipClick, AudioClip audioClipSwitch,
            AudioClip audioClipBackgroundMusic);

        public void PlayClick();
        public void PlayChangeSkin();
        public void SetVolumeIcon(bool isEnable);
        public event Action OnClickButtonVolume;


    }
}
