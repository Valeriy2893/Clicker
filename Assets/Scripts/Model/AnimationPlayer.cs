using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private AnimationClip _animationClip;

    public void PlayAnimation()
    {
        SetStatusAnimation();
        var normalizedTime = 0.0f;
        var layer = -1;
        _animator.Play(_animationClip.name, layer, normalizedTime);
    }

    private void SetStatusAnimation()
    {
        if (!_animator.enabled)
        {
            _animator.enabled = true;
        }
    }
    private void OnDisable()
    {
        _animator.enabled = false;
    }
}


