using UnityEngine;

public class Price : MonoBehaviour
{
    private int _priceClick;
    private int _priceClickSec;
    private int _priceFactorClick;
    private int _priceChanceFactorClick;
    private int _priceFactorClickSec;

    private int _defaultFactor = 2;
    public int GetPriceClick()
    {
        return GetValidPrice(_priceClick);
    }
    public int GetPriceFactorClick()
    {
        return GetValidPrice(_priceFactorClick);
    }
    public int GetPriceChanceFactorClick()
    {
        return GetValidPrice(_priceChanceFactorClick);
    }
    public int GetPriceClickSec()
    {
        return GetValidPrice(_priceClickSec);
    }
    public int GetPriceFactorClickSec()
    {
        return GetValidPrice(_priceFactorClickSec);
    }
    public void AddPriceClick()
    {
        _priceClick = GetValidPrice(_priceClick);
        _priceClick *= _defaultFactor;
    }
    public void AddPriceFactorClick()
    {
        _priceFactorClick = GetValidPrice(_priceFactorClick);
        _priceFactorClick *= _defaultFactor;
    }

    public void AddPriceChanceFactorClick()
    {
        _priceChanceFactorClick = GetValidPrice(_priceChanceFactorClick);
        _priceChanceFactorClick *= _defaultFactor;
    }
    public void AddPriceClickSec()
    {
        _priceClickSec = GetValidPrice(_priceClickSec);
        _priceClickSec *= _defaultFactor;
    }
    public void AddPriceFactorClickSec()
    {
        _priceFactorClickSec = GetValidPrice(_priceFactorClickSec);
        _priceFactorClickSec *= _defaultFactor;
    }

    private int GetValidPrice(int price)
    {
        if (price <= 0)
        {
            return 1;
        }
        else
        {
            return price;
        }
    }
}
