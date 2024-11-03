using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour,IVolumeView
{
    [SerializeField] private AudioSource _sourceClick;
    [SerializeField] private AudioSource _changeSkin;
    [SerializeField] private AudioSource _backgroundMusic;
    
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buttonSwichVolume;
    
    private Sprite _spriteOff;
    private Sprite _spriteOn;
    public event Action OnClickButtonVolume;
    
    public void Init(Sprite spriteOff, Sprite spriteOn, AudioClip audioClipClick, AudioClip audioClipSwitch, AudioClip audioClipBackgroundMusic)
    {
        SetSprites(spriteOff, spriteOn);
        SetAudioClips(audioClipClick, audioClipSwitch, audioClipBackgroundMusic);
        PlayBackgroundMusic();
        _buttonSwichVolume.onClick.AddListener(() => OnClickButtonVolume?.Invoke());
    }
    public void PlayClick() => _sourceClick.Play();
    public void PlayChangeSkin() => _changeSkin.Play();
    public void SetVolumeIcon(bool isEnable) => _icon.sprite = isEnable ? _spriteOn : _spriteOff;
    private void SetSprites(Sprite spriteOff, Sprite spriteOn)
    {
        _spriteOff = spriteOff;
        _spriteOn = spriteOn;
    }

    private void SetAudioClips(AudioClip audioClipClick, AudioClip audioClipSwitch, AudioClip audioClipBackgroundMusic)
    {
        _sourceClick.clip = audioClipClick;
        _changeSkin.clip = audioClipSwitch;
        _backgroundMusic.clip = audioClipBackgroundMusic;
    }
    private void PlayBackgroundMusic() => _backgroundMusic.Play();
    private void OnDisable() => _buttonSwichVolume.onClick.RemoveAllListeners();
}
