using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Data Data { get; private set; }
    public Progress Progress { get; private set; }

    [SerializeField] private SpawnerAnimals _spawner;

    public event Action OnClickAnimal;
   
    [SerializeField] private Audio _audio;
    [SerializeField] private FXClick _fxClick;

    [SerializeField] private PoolFlyText _poolFlyText;

    [SerializeField] private DataUI _dataUI;

    private void Awake()
    {
        Data = new(this, _spawner);
        Progress = new Progress(this);
    }

    public void OnClick(RaycastHit hit)
    {
        OnClickAnimal?.Invoke();

        //Data.IsFactorClick();

        GiveDataForTextFly(hit, Data.CurrentFactorClick);
        _fxClick.SetPositionFX(hit);

    }

    private void GiveDataForTextFly(RaycastHit hit, bool isFactor)
    {
        var _currentText = _poolFlyText.GetFlyText();
        _currentText.GetComponent<TextFly>().InitializationTextFly(hit, _poolFlyText, isFactor);
    }

}
