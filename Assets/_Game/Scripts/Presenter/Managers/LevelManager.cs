using System;
using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Services.Abstract;
using _Game.Scripts.View.Abstracts;
using R3;

namespace _Game.Scripts.Presenter.Managers
{
    public class LevelManager : IDisposable
    {
        private readonly ILevelProgression _levelProgression;
        private readonly IClickCalculator _clickCalculator;
        private readonly CompositeDisposable _disposable = new();

        public LevelManager(ILevelProgression levelProgression, ILevelView levelView, IClickCalculator clickCalculator)
        {
            _levelProgression = levelProgression;
            _clickCalculator = clickCalculator;
            clickCalculator.ClickCalculated += AddExperience;

            levelProgression.CurrentLevel
                .Subscribe(value => levelView.SetLevelText(value.ToString())).AddTo(_disposable);

            levelProgression.ExperienceRequiredForNextLevel
                .Subscribe(value => levelView.SetSliderMaxValue(value)).AddTo(_disposable);

            levelProgression.Experience
                .Subscribe(value => levelView.SetSliderValue(value)).AddTo(_disposable);
        }

        public void Dispose()
        {
            _clickCalculator.ClickCalculated -= AddExperience;
            _disposable.Dispose();
        }

        private void AddExperience(int amount) => _levelProgression.TryAddExperience(amount);
    }
}