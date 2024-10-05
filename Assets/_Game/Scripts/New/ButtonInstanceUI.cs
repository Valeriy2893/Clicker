using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInstanceUI
{ 
    private readonly Image _icon;
    private readonly TMP_Text _name;
    private readonly TMP_Text _price;
    private readonly TMP_Text _count;
    private readonly Button _clickButton;
    public ButtonInstanceUI(ButtonUI buttonUI,Sprite icon,string name)
    {
        _icon = buttonUI.Icon;
        _name = buttonUI.Name;
        _price = buttonUI.Price;
        _count = buttonUI.Count;
        _clickButton= buttonUI.ClickButton;
        
        _icon.sprite = icon;
        _name.text = name;
        
        // _clickButton.onClick.AddListener(OnClickButton);
    }
    
    
}
