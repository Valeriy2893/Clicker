using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour, IVolumeUI
{
    [SerializeField] private GameObject _off;
    [SerializeField] private GameObject _on;

    [SerializeField] private Button _buttonSwichVolume;
    private Volume volume;

    private void Start()
    {
        volume = new Volume(this);

        _buttonSwichVolume.onClick.AddListener(() => volume.VolumeControl());
    }
    public void Switch(bool isEnable)
    {
        _off.SetActive(!isEnable);
        _on.SetActive(isEnable);
    }
    private void OnDestroy()
    {
        _buttonSwichVolume.onClick.RemoveAllListeners();
    }
}
