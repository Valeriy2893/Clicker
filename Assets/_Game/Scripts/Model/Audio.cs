using UnityEngine;
using UnityEngine.Serialization;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceClick;
    [SerializeField] private AudioSource _changeSkin;
    [FormerlySerializedAs("animal")] [SerializeField] private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnClickAnimal += PlayClick;

    }

    private void PlayClick()
    {
        _sourceClick.Play();
    }
    public void PlayChangeSkin()
    {
        _changeSkin.Play();
    }
    private void OnDestroy()
    {
        player.OnClickAnimal -= PlayClick;
    }
}
