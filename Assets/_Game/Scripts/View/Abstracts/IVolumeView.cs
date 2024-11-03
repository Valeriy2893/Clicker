using System;
using UnityEngine;

public interface IVolumeView
{
    public void Init(Sprite spriteOff, Sprite spriteOn, AudioClip audioClipClick, AudioClip audioClipSwitch,
        AudioClip audioClipBackgroundMusic);

    public void PlayClick();
    public void PlayChangeSkin();
    public void SetVolumeIcon(bool isEnable);
    public event Action OnClickButtonVolume;


}
