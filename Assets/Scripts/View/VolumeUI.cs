using UnityEngine;

public class VolumeUI : MonoBehaviour
{
    [SerializeField] private GameObject _off;
    [SerializeField] private GameObject _on;

    public void SetVolumeImage(bool isVolume)
    {
        _off.SetActive(!isVolume);
        _on.SetActive(isVolume);
    }
}
