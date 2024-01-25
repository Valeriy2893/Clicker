using System.Collections.Generic;
using UnityEngine;

public class SkinSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _skins;
    [SerializeField] private Audio _audio;
    [SerializeField] private FXClick _fXClick;

    private List<GameObject> _FreeSkins = new();
    private GameObject _currentSkins;
    private AnimationPlayer currentAnimationPlayer;
    private int indexSkin;
    private void Start()
    {
        CreateNewSkin();
        SetCurrentAnimationPlayer();
    }
    public AnimationPlayer GetCurrentAnimationPlayer()
    {
       return currentAnimationPlayer;
    }
    private void SetCurrentAnimationPlayer()
    {
        currentAnimationPlayer = _currentSkins.GetComponent<AnimationPlayer>();
    }
    public void ChangeSkin()
    {
        indexSkin++;
        _fXClick.CreateFXChangeSkin();
        _audio.PlayChangeSkin();

        _currentSkins.SetActive(false);
        _FreeSkins.Add(_currentSkins);
        GetNewSkin();

        SetCurrentAnimationPlayer();
        _currentSkins.SetActive(true);
    }

    private void GetNewSkin()
    {
        if (_FreeSkins.Count >= _skins.Count)
        {
            var minInclusive = 0;
            _currentSkins = _FreeSkins[Random.Range(minInclusive, _FreeSkins.Count)];
            _FreeSkins.Remove(_currentSkins);
        }
        else
        {
            CreateNewSkin();
        }
    }

    private void CreateNewSkin()
    {
        _currentSkins = Instantiate(_skins[indexSkin % _skins.Count], transform);
    }
}
