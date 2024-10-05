using TMPro;
using UnityEngine;

public class TextFlyUI : MonoBehaviour
{
    [field: SerializeField] public TMP_Text TextFly { get; private set; }
    [SerializeField] private Player clickHandler;

    public void SelectColor(bool isFactorClick)
    {
        if (isFactorClick)
        {
            TextFly.color = Color.red;
        }
        else
        {
            TextFly.color = Color.black;
        }
    }
    public void SelectFontSize(bool isFactorClick)
    {
        if (isFactorClick)
        {
            var maxSize = 100;
            TextFly.fontSize = maxSize;
        }
        else
        {
            var minSize = 45;
            TextFly.fontSize = minSize;
        }
    }
    public void ShowTextFly(bool isFactorClick)
    {
        clickHandler = FindObjectOfType<Player>();

        // if (isFactorClick)
        // {
        //     TextFly.text = "+" + FormatLargeNumber.ModificationInt(clickHandler.Data.GetValue(TypeButton.Click) * clickHandler.Data.GetValue(TypeButton.FactorClick));
        // }
        // else
        // {
        //
        //     TextFly.text = "+" + FormatLargeNumber.ModificationInt(clickHandler.Data.GetValue(TypeButton.Click));
        // }
    }
}
