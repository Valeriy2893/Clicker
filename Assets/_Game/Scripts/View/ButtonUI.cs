using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI: MonoBehaviour,IButtonView
{ 
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private Button _clickButton;
    public event Action OnClickButton;
    public void Init(Sprite icon, string nameButton)
    {
        _icon.sprite=icon;
        _name.text=nameButton;
        _clickButton.onClick.AddListener(()=>OnClickButton?.Invoke());
    }
    public void OnValueChanged(string value)=> _count.text = value;
    public void OnPriceChanged(string price)=> _price.text = price;
    public void SetInteractable(bool canAfford,TypeButton buttonType,int value)
    { 
        _clickButton.interactable = canAfford;
        
        if (buttonType != TypeButton.ChanceFactorClick || value < 100) return;
        _clickButton.interactable = false;
        _count.gameObject.SetActive(false);
        _price.gameObject.SetActive(false);
    }
    private void OnDisable()
        =>_clickButton.onClick.RemoveAllListeners();
}
