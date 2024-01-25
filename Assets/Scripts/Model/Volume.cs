using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private VolumeUI _volumeUI;

    private int _enableVolume = 1;
    private int _disableVolume = 0;
    private void Start()
    {
        VolumeStart();
    }
    public void VolumeControl()
    {
        if (AudioListener.volume == _enableVolume)
        {
            AudioListener.volume = _disableVolume;

            _volumeUI.SetVolumeImage(false);
        }
        else if (AudioListener.volume == _disableVolume)
        {
            AudioListener.volume = _enableVolume;

            _volumeUI.SetVolumeImage(true);
        }
    }
    private void VolumeStart()
    {
        if (AudioListener.volume == _enableVolume)
        {
            _volumeUI.SetVolumeImage(true);
        }
        else if (AudioListener.volume == _disableVolume)
        {
            _volumeUI.SetVolumeImage(false);
        }
    }
}
