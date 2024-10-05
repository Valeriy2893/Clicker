using UnityEngine;

public class Volume
{
    private IVolumeUI _volumeUI;

    private const int EnableVolume = 1;
    private const int DisableVolume = 0;

    public Volume(IVolumeUI volumeUI)
    {
        _volumeUI = volumeUI;
        VolumeStart();
    }
    public void VolumeControl()
    {
        if (AudioListener.volume == EnableVolume)
        {
            AudioListener.volume = DisableVolume;

            _volumeUI.Switch(false);
        }
        else if (AudioListener.volume == DisableVolume)
        {
            AudioListener.volume = EnableVolume;

            _volumeUI.Switch(true);
        }
    }
    private void VolumeStart()
    {
        if (AudioListener.volume == EnableVolume)
        {
            _volumeUI.Switch(true);
        }
        else if (AudioListener.volume == DisableVolume)
        {
            _volumeUI.Switch(false);
        }
    }
}
