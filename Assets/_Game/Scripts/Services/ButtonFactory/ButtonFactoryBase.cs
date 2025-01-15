using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter.Abstracts;
using UnityEngine;

namespace _Game.Scripts.Services.ButtonFactory
{
    public abstract class ButtonFactoryBase
    {
        protected readonly Transform ParentButtons;
        protected readonly ICurrencyProvider CurrencyProvider;
        private readonly ResourcesManager _resourcesManager;
        protected List<ButtonPassport> ButtonsPassport { get; }

        protected ButtonFactoryBase(ResourcesManager resourcesManager, Transform parentButtons,
            ICurrencyProvider currencyProvider)
        {
            _resourcesManager = resourcesManager;
            ParentButtons = parentButtons;
            CurrencyProvider = currencyProvider;
            ButtonsPassport = GetButtonsPassport();
        }

        public abstract List<IButtonMain> CreateButtons();

        private List<ButtonPassport> GetButtonsPassport()
        {
            return _resourcesManager.GetAllButtonsPassport()
                .OrderBy(item => item.Order)
                .ToList();
        }
    }
}