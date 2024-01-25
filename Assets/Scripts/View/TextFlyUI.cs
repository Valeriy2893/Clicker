using TMPro;
using UnityEngine;

public class TextFlyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textFly;
    public TMP_Text GetTextFly()
    {
        return _textFly;
    }

    public void SelectColor(bool isFactorClick)
    {
        if (isFactorClick)
        {
            _textFly.color = Color.red;
        }
        else
        {
            _textFly.color = Color.black;
        }
    }
    public void SelectFontSize(bool isFactorClick)
    {
        if (isFactorClick)
        {
            var maxSize = 100;
            _textFly.fontSize = maxSize;
        }
        else
        {
            var minSize = 45;
            _textFly.fontSize = minSize;
        }
    }
    public void ShowTextFly(bool isFactorClick)
    {
        Data _data;
        NumberFormatter _numberFormatter;
        FindReferences(out _data, out _numberFormatter);

        if (isFactorClick)
        {
            _textFly.text = "+" + _numberFormatter.ModificationInt(_data.GetClick() * _data.GetFactorClick());
        }
        else
        {

            _textFly.text = "+" + _numberFormatter.ModificationInt(_data.GetClick());
        }
    }

    private void FindReferences(out Data _data, out NumberFormatter _numberFormatter)
    {
        _data = FindObjectOfType<Data>();
        _numberFormatter = FindObjectOfType<NumberFormatter>();
    }
}
