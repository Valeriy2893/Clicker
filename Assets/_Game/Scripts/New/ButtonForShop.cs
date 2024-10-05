using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonUI
{
    public Image Icon;
    public TMP_Text Name;
    public TMP_Text Price;
    public TMP_Text Count;
    public Button ClickButton;
}
public class ButtonForShop : MonoBehaviour
{
    [SerializeField] private ButtonUI buttonUI;
    private ButtonInstanceUI buttonInstanceUI;
    public TypeButton TypeButton { get; private set; }
    private Player _player;
    private ButtonInstance _buttonInstance; 
    public void Init(ButtonPassport buttonsPassport, Player player)
    {
        buttonInstanceUI = new ButtonInstanceUI(buttonUI,buttonsPassport.Icon,buttonsPassport.Name);
        TypeButton = buttonsPassport.TypeButton;
        _player = player;

        _buttonInstance = new ButtonInstance(buttonsPassport);
        
        _buttonInstance.Value.Subscribe(value =>
        {
            buttonUI.Count.text = FormatLargeNumber.ModificationInt(value);
            if (TypeButton != TypeButton.ChanceFactorClick) return;
            if (_buttonInstance.Value.CurrentValue < 100) return;
            GetComponent<Button>().interactable = false;
            buttonUI.Price.transform.parent.gameObject.SetActive(false);
        }).AddTo(this);
           
        _buttonInstance.Price.Subscribe(value =>
        { 
            buttonUI.Price.text = FormatLargeNumber.ModificationInt(value);
            GetComponent<Button>().interactable = value <= _player.Progress.Wallet.AllCoins.CurrentValue;
        }).AddTo(this);
        
        GetComponent<Button>().onClick.AddListener(OnClickButton);
    }
    private void OnClickButton()
    {
        if (_player.Progress.Wallet.TryRemoveCoins(_buttonInstance.Price.CurrentValue))
        {
            _buttonInstance.AddValue();
        }

    }
   
}
