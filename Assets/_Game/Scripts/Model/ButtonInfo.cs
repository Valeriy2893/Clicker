using R3;
using UnityEngine;

public class ButtonInfo: IButtonInfo
{
    public TypeButton TypeButton { get; }
    public ReadOnlyReactiveProperty<int> Value => _value;
    public ReadOnlyReactiveProperty<int> Price => _price;
    
    private readonly ReactiveProperty<int> _value=new();
    private readonly ReactiveProperty<int> _price=new();
    
    private readonly int _defaultValue;
    private readonly int _defaultPrice;
    private readonly float _factorPrice;
    
    public ButtonInfo(TypeButton typeButton,int value, int price,float factorPrice)
    {
        TypeButton = typeButton;
        _defaultValue=value;
        _defaultPrice=price;
        _factorPrice=factorPrice;
        
        _value.Value = value;
        _price.Value = price;
    }
    public void AddValue()
    {
        if (!CanAddValue()) return;

        _value.Value++;
        CalculatePrice();
    }

    public bool CanAddValue() 
        => !(_factorPrice <= 0) && _defaultPrice > 0 && _defaultValue >= 0 && _price.Value > 0;

    private void CalculatePrice()
    {
        var price = Mathf.CeilToInt(_factorPrice * _price.Value);
        _price.Value = price;
    }
}