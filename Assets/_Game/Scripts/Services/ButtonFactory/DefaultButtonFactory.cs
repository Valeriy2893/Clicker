using System.Collections.Generic;
using _Game.Scripts.Model;
using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter;
using _Game.Scripts.Presenter.Abstracts;
using _Game.Scripts.View.Abstracts;
using UnityEngine;

namespace _Game.Scripts.Services.ButtonFactory
{
    public class DefaultButtonFactory : ButtonFactoryBase
    {
        public DefaultButtonFactory(ResourcesManager resourcesManager, Transform parentButtons,
            ICurrencyProvider currencyProvider) : base(resourcesManager, parentButtons, currencyProvider) { }

        public override List<IButtonMain> CreateButtons()
        {
            List<IButtonMain> buttonMains = new();

            foreach (var buttonPassport in ButtonsPassport)
            {
                var buttonInfo = CreateButtonInfo(buttonPassport);
                if (buttonInfo == null) continue;

                var buttonUI = CreateButtonUI(buttonPassport);
                if (buttonUI == null) continue;

                var buttonMain = new ButtonMain(buttonInfo, buttonUI, CurrencyProvider);

                buttonMains.Add(buttonMain);
            }

            return buttonMains;
        }

        private IButtonInfo CreateButtonInfo(ButtonPassport buttonPassport)
        {
            return buttonPassport == null
                ? null
                : new ButtonInfo(buttonPassport.TypeButton, buttonPassport.DefaultValue, buttonPassport.DefaultPrice,
                    buttonPassport.FactorPrice);
        }

        private IButtonView CreateButtonUI(ButtonPassport buttonPassport)
        {
            var buttonInstance = Object.Instantiate(buttonPassport.Prefab, ParentButtons);
            var buttonUI = buttonInstance.GetComponent<IButtonView>();
            buttonUI.Init(buttonPassport.Icon, buttonPassport.Name);
            return buttonUI;
        }
    }
}