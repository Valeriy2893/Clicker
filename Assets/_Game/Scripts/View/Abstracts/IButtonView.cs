using System;
using UnityEngine;

public interface IButtonView
{
    public event Action OnClickButton;
    public void Init(Sprite icon, string nameButton);
    public void OnValueChanged(string value);
    public void OnPriceChanged(string price);
    public void SetInteractable(bool canAfford, bool isInteractableChangeFactor);
}