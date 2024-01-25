using UnityEngine;
using UnityEngine.UI;

public class SliderLevel : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private Data _data;
    [SerializeField] private DataUI _dataUI;
    [SerializeField] private SkinSpawner _spawner;

    private void Start()
    {
        _slider.maxValue = _data.GetMaxValueSlider();
    }
    public void AddValueSlider(bool isFactorClick)
    {
        if (_slider.value >= _slider.maxValue)
        {
            _data.AddLevel();
            _spawner.ChangeSkin();
            _data.AddMaxValueSlider();
            SetDefaultValue();
            _slider.maxValue = _data.GetMaxValueSlider();
            _dataUI.ShowLevel();
        }
        else
        {
            if (!isFactorClick)
            {
                _slider.value += _data.GetClick();
            }
            else
            {
                _slider.value += _data.GetClick() * _data.GetClick();
            }
        }
    }

    private void SetDefaultValue()
    {
        _slider.value = 0;
    }
}



