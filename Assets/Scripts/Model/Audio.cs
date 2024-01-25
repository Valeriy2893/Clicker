using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceClick;
    [SerializeField] private AudioSource _changeSkin;

    public void PlayClick()
    {
        _sourceClick.Play();
    }
    public void PlayChangeSkin()
    {
        _changeSkin.Play();
    }
}
