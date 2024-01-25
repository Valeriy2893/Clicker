using UnityEngine;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _click;
    [SerializeField] private Button _factorClick;
    [SerializeField] private Button _chanceFactorClick;
    [SerializeField] private Button _clickSec;
    [SerializeField] private Button _factorClickSec;

    [SerializeField] private GameObject _ImagePriceChanceFactor;

    [SerializeField] private Price _price;
    [SerializeField] private Data _data;
    private void Start()
    {
        DisableButtons();
    }
    public void DisableButtons()
    {
        SetInteractableButton(_click, _price.GetPriceClick());
        SetInteractableButton(_factorClick, _price.GetPriceFactorClick());
        SetInteractableButtonChanceFactorClick();
        SetInteractableButton(_clickSec, _price.GetPriceClickSec());
        SetInteractableButton(_factorClickSec,_price.GetPriceFactorClickSec()); 
    }

    private void SetInteractableButton(Button button,int price)
    {
        if (price > _data.GetAllCoins())
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    private void SetInteractableButtonChanceFactorClick()
    {
        var maxValue = 100;
        if (_data.GetChanceFactorClick() < maxValue)
        {
            if (_price.GetPriceChanceFactorClick() > _data.GetAllCoins())
            {
                _chanceFactorClick.interactable = false;
            }
            else
            {
                _chanceFactorClick.interactable = true;
            }
        }
        else
        {
            _chanceFactorClick.interactable = false;
            _ImagePriceChanceFactor.SetActive(false);
        }
    }

}

