using R3;
using UnityEngine;
using UnityEngine.UI;

public class SliderLevel : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private Data _data;
    [SerializeField] private SpawnerAnimals _spawner;
    [SerializeField] private Player clickHandler;
    private void Start()
    {
        clickHandler = FindObjectOfType<Player>();
        _data = clickHandler.Data;
        _slider.maxValue = clickHandler.Progress.GetMaxValueSlider();
        clickHandler.OnClickAnimal += AddValueSlider;

        
        clickHandler.Progress.LevelProgression.Level.Subscribe(newValue=> SetDefaultValue());
    }
    public void AddValueSlider()
    {
        // if (!_data.CurrentFactorClick)
        // {
        //     _slider.value += _data.GetValue(TypeButton.Click);
        // }
        // else
        // {
        //     _slider.value += _data.GetValue(TypeButton.Click) * _data.GetValue(TypeButton.Click);
        // }
    }

    private void SetDefaultValue()
    {
        _slider.value = 0;
        _slider.maxValue = clickHandler.Progress.GetMaxValueSlider();
    }
    private void OnDestroy()
    {
        // clickHandler.OnClickAnimal -= AddValueSlider;
        // clickHandler.AnimalProgress.OnLevelUp -= SetDefaultValue;
    }
}



