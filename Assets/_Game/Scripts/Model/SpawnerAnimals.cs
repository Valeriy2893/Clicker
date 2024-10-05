using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class SpawnerAnimals : MonoBehaviour
{
    [SerializeField] private List<GameObject> _skins;
    [SerializeField] private Audio _audio;
    [SerializeField] private FXClick _fXClick;

    private List<GameObject> _FreeSkins = new();
    private GameObject _currentSkins;
    private AnimationAnimal _currentAnimationAnimal;
    private int indexSkin;
    [FormerlySerializedAs("animal")] [FormerlySerializedAs("clickModel")] [SerializeField] private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        CreateNewSkin();
        SetCurrentAnimationPlayer();

        // animal.AnimalProgress.OnLevelUp += ChangeSkin;
    }
    private void SetCurrentAnimationPlayer()
    {
        _currentAnimationAnimal = _currentSkins.GetComponent<AnimationAnimal>();
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
            _currentSkins = _FreeSkins[UnityEngine.Random.Range(minInclusive, _FreeSkins.Count)];
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
    private void OnDestroy()
    {
        // animal.AnimalProgress.OnLevelUp += ChangeSkin;
    }
}
