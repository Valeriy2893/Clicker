using UnityEngine;
using UnityEngine.Serialization;

public class AnimationAnimal : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _animationClip;
    [FormerlySerializedAs("animal")] [SerializeField] private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnClickAnimal += PlayAnimation;
    }

    private void PlayAnimation()
    {
        SetStatusAnimation();
        var normalizedTime = 0.0f;
        var layer = -1;
        _animator.Play(_animationClip.name, layer, normalizedTime);
    }

    private void SetStatusAnimation()
    {
        if (_animator.enabled) return;
        _animator.enabled = true;
    }
    private void OnDisable()
    {
        player.OnClickAnimal -= PlayAnimation;
        _animator.enabled = false;
      
    }
}


