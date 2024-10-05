using R3;

public class ButtonInstance
{
    public ReadOnlyReactiveProperty<int> Value => _value;
    private readonly ReactiveProperty<int> _value=new();
    
    public ReadOnlyReactiveProperty<int> Price => _price;
    private readonly ReactiveProperty<int> _price=new();
    
    private ButtonPassport _passport;
    public ButtonInstance(ButtonPassport passport)
    {
        _passport = passport;
        AddValue();
    }
    
    public void AddValue()
    {
        if (_passport == null) return;
        if (_passport.DefaultValue == 0) return;
        
        if (_value.Value<=0)
        {
            _value.Value= _passport.DefaultValue;
        }
        else
        {
            _value.Value++;
        }

        CalculatePrice();
    }
    
    private void CalculatePrice()
    {
        if (_passport == null) return;
        if (_passport.DefaultPrice == 0) return;
        if (_passport.FactorPrice == 0) return;
        
        if (_price.Value>0)
        {
            _price.Value*=_passport.FactorPrice;
        }
        else
        {
            _price.Value=_passport.DefaultPrice;
        }
    }
    // public void AddPrice(TypeButton typeButton)
    // {
    //     /// Подумать
    //     var buttons = Object.FindObjectOfType<SpawnerButtons>().GetAllButtons();
    //     foreach (var item in buttons)
    //     {
    //         if (item.TypeButton == typeButton)
    //         {
    //             item.UpdateTextPrice(_prices[typeButton]);
    //         }
    //     }
    // }
}
