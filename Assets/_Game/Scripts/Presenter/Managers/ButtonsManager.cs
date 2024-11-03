using System.Collections.Generic;
using System.Linq;

public class ButtonsManager
{
    public List<ButtonMain> MainButtons { get;}
    public AutoClickService AutoClickService{ get;}
    
    public ButtonsManager(SpawnerButtons spawnerButtons, AutoClickService autoClickService)
    {
        MainButtons=spawnerButtons.CreateButtons();
        AutoClickService = autoClickService;
        
        InitializeAutoClick();
    }
    private void InitializeAutoClick()
    {
        var buttonMainClickSec = GetTypeButton(TypeButton.ClickSec);
        var buttonMainFactorClickSec = GetTypeButton(TypeButton.FactorClickSec);
        
        if (buttonMainClickSec == null || buttonMainFactorClickSec == null) return;
        
        AutoClickService.Initialize(buttonMainClickSec, buttonMainFactorClickSec);
    }
    public ButtonMain GetTypeButton(TypeButton typeButton)
        => MainButtons.FirstOrDefault(buttonMain => buttonMain.TypeButton == typeButton);
}
