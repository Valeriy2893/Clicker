using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI: MonoBehaviour,ILevelView
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Slider _slider;
    
    public void SetLevelText(string levelText) => _level.text = levelText;
    public void SetSliderValue(float value) => _slider.value = value;
    public void SetSliderMaxValue(float maxValue) => _slider.maxValue=maxValue;
}
