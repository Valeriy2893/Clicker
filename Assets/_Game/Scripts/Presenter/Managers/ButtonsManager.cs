using System;
using System.Collections.ObjectModel;
using System.Linq;
using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter.Abstracts;
using _Game.Scripts.Services;
using _Game.Scripts.Services.ButtonFactory;

namespace _Game.Scripts.Presenter.Managers
{
    public class ButtonsManager: IDisposable
    {
        public ReadOnlyCollection<IButtonMain> MainButtons { get;}
        public AutoClickService AutoClickService{ get;}
        public ButtonsManager(ButtonFactoryBase buttonFactory, AutoClickService autoClickService)
        {
            MainButtons = buttonFactory.CreateButtons().AsReadOnly();
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
        public IButtonMain GetTypeButton(TypeButton typeButton)
            => MainButtons.FirstOrDefault(buttonMain => buttonMain.TypeButton == typeButton);

        public void Dispose()
        {
            AutoClickService?.Dispose();
            
            foreach (var mainButton in MainButtons)
                mainButton.Dispose();
        }
    }
}
