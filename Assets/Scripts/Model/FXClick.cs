using UnityEngine;

public class FXClick : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fXClick;

    [SerializeField] private GameObject _prefabFXChangeSkin;

    private ParticleSystem _fXChangeSkin;
    public void SetPositionFX(RaycastHit hit)
    {
        _fXClick.transform.position = hit.point;
        PlayAnimation();
    }
    public void CreateFXChangeSkin()
    {
        if (_fXChangeSkin == null)
        {
            _fXChangeSkin = Instantiate(_prefabFXChangeSkin).GetComponent<ParticleSystem>();
        }
        _fXChangeSkin.Play();
    }
    private void PlayAnimation()
    {
        _fXClick.Play();
    }
}
