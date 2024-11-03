using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerButtons
{
    private readonly ResourcesManager _resourcesManager;
    private readonly Transform _parentButtons;
    private readonly ICurrencyProvider _currencyProvider;

    public SpawnerButtons(ResourcesManager resourcesManager, Transform parentButtons, ICurrencyProvider currencyProvider)
    {
        _resourcesManager = resourcesManager;
        _parentButtons = parentButtons;
        _currencyProvider = currencyProvider;
    }
    
    public List<ButtonMain> CreateButtons()
    {
        var sortedButtons = GetButtonsPassport();
        List<ButtonMain> buttonMains = new();

        foreach (var buttonPassport in sortedButtons)
        {
            var buttonInfo = CreateButtonInfo(buttonPassport);
            if (buttonInfo == null) continue;

            var buttonUI = CreateButtonUI(buttonPassport);
            if (buttonUI == null) continue;

            var buttonMain = new ButtonMain(buttonInfo, buttonUI, _currencyProvider);
            buttonMains.Add(buttonMain);
        }
        
        return buttonMains;
    }
    private IButtonInfo CreateButtonInfo(ButtonPassport buttonPassport)
    {
        return buttonPassport == null
            ? null
            : new ButtonInfo(buttonPassport.TypeButton, buttonPassport.DefaultValue, buttonPassport.DefaultPrice, buttonPassport.FactorPrice);
    }

    private IButtonView CreateButtonUI(ButtonPassport buttonPassport)
    {
        var buttonInstance = Object.Instantiate(buttonPassport.Prefab, _parentButtons);
        var buttonUI = buttonInstance.GetComponent<IButtonView>();
        buttonUI.Init(buttonPassport.Icon, buttonPassport.Name);
        return buttonUI;
    }
    
    private List<ButtonPassport> GetButtonsPassport()
    {
        return _resourcesManager.GetAllButtonsPassport()
            .OrderBy(item => item.Order)
            .ToList();
    }
}