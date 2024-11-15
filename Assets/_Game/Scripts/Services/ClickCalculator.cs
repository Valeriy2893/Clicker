using System;
using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter.Managers;
using _Game.Scripts.Services.Abstract;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Services
{
    public class ClickCalculator: IClickCalculator
    {
        private const int minInclusive = 1;
        private const int maxExclusive = 101;
    
        private readonly ButtonsManager _buttonsManager;
        public event Action<int, bool> ClickCalculatedWithFactor;
        public event Action<int> ClickCalculated;

        public ClickCalculator(IClickHandler clickHandler,ButtonsManager buttonsManager)
        {
            _buttonsManager = buttonsManager;
            clickHandler.ClickedAnimal += CalculateClickValue;
        }
        private void CalculateClickValue()
        {
            var clickValue = _buttonsManager.GetTypeButton(TypeButton.Click).Value.CurrentValue;
            var factorValue = _buttonsManager.GetTypeButton(TypeButton.FactorClick).Value.CurrentValue;
            var chanceValue = _buttonsManager.GetTypeButton(TypeButton.ChanceFactorClick).Value.CurrentValue;

            var isFactorActive = IsFactorClick(chanceValue);
            var currentClick=isFactorActive ? clickValue * factorValue : clickValue;
        
            ClickCalculated?.Invoke(currentClick);
            ClickCalculatedWithFactor?.Invoke(currentClick, isFactorActive);
        }

        private bool IsFactorClick(int chanceValue) 
            => Random.Range(minInclusive, maxExclusive) <= chanceValue;
    }
}