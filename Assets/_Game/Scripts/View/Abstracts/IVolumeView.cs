using System;
using UnityEngine;

namespace _Game.Scripts.View.Abstracts
{
    public interface IVolumeView
    {
        public event Action ClickedButtonVolume;
        public void Init(Sprite spriteOff, Sprite spriteOn, AudioClip audioClipClick, AudioClip audioClipSwitch,
            AudioClip audioClipBackgroundMusic);
        public void PlayClick();
        public void PlayChangeSkin();
        public void SetVolumeIcon(bool isEnable);
    }
}