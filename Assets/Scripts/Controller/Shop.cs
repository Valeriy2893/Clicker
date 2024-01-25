using UnityEngine;

public partial class Shop : MonoBehaviour
{
    [SerializeField] private Data _data;
    [SerializeField] private Price _price;

    [SerializeField] private DataUI _dataUI;
    [SerializeField] private PriceUI _priceUI;
    [SerializeField] private ButtonsHandler _buttonsHandler;
 
    public void BuyClick()
    {
        if (_data.TryRemoveCoins(_price.GetPriceClick()))
        {
            _data.AddClick();
            _price.AddPriceClick();

            _priceUI.ShowPriceClick();
            _dataUI.ShowClick();
            _dataUI.ShowAllCoins();
        }
        _buttonsHandler.DisableButtons();
    }
    public void BuyFactorClick()
    {
        if (_data.TryRemoveCoins(_price.GetPriceFactorClick()))
        {
            _data.AddFactorClick();
            _price.AddPriceFactorClick();

            _priceUI.ShowPriceFactorClick();
            _dataUI.ShowFactorClick();
            _dataUI.ShowAllCoins();
        }

        _buttonsHandler.DisableButtons();
    }
    public void BuyChanceFactorClick()
    {
        if (_data.TryRemoveCoins(_price.GetPriceChanceFactorClick()))
        {
            _data.AddChanceFactorClick();
            _price.AddPriceChanceFactorClick();

            _priceUI.ShowPriceChanceFactorClick();
            _dataUI.ShowChanceFactorClick();
            _dataUI.ShowAllCoins();
        }

        _buttonsHandler.DisableButtons();
    }
    public void BuyClickSec()
    {
        if (_data.TryRemoveCoins(_price.GetPriceClickSec()))
        {
            _data.AddClickSec();
            _price.AddPriceClickSec();

            _priceUI.ShowPriceClickSec();
            _dataUI.ShowClickSec();
            _dataUI.ShowAllCoins();
        }

        _buttonsHandler.DisableButtons();
    }
    public void BuyFactorClickSec()
    {
        if (_data.TryRemoveCoins(_price.GetPriceFactorClickSec()))
        {
            _data.AddFactorClickSec();
            _price.AddPriceFactorClickSec();

            _priceUI.ShowPriceFactorClickSec();
            _dataUI.ShowFactorClickSec();
            _dataUI.ShowAllCoins();
        }
        _buttonsHandler.DisableButtons();
    }
}

