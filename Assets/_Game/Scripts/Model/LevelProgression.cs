using System.Collections.Generic;
using _Game.Scripts.Model.Abstracts;
using R3;
using UnityEngine;

namespace _Game.Scripts.Model
{
    public class LevelProgression : ILevelProgression
    {
        private readonly ReactiveProperty<int> _level = new();
        private readonly ReactiveProperty<int> _experience = new();
        private readonly ReactiveProperty<int> _experienceRequiredForNextLevel = new();
        private readonly IReadOnlyList<int> _experienceRequirements;

        public ReadOnlyReactiveProperty<int> CurrentLevel => _level;
        public ReadOnlyReactiveProperty<int> ExperienceRequiredForNextLevel => _experienceRequiredForNextLevel;
        public ReadOnlyReactiveProperty<int> Experience => _experience;

        public LevelProgression(IReadOnlyList<int> experienceRequirements, int level, int experience)
        {
            _experienceRequirements = experienceRequirements;
            _level.Value = level;
            _experience.Value = experience;
            _experienceRequiredForNextLevel.Value = GetExperienceRequiredForNextLevel(_level.Value);
        }

        public bool TryAddExperience(int experience)
        {
            if (experience <= 0 || _experience.Value >= int.MaxValue) return false;

            var requiredExperience = _experienceRequiredForNextLevel.Value - _experience.Value;

            while (experience >= requiredExperience)
            {
                if (!TryAddLevel()) return false;

                experience -= requiredExperience;

                requiredExperience = _experienceRequiredForNextLevel.Value;
            }

            _experience.Value += experience;

            return true;
        }

        private bool TryAddLevel()
        {
            if (_level.Value >= int.MaxValue) return false;

            _level.Value++;
            _experience.Value = 0;
            _experienceRequiredForNextLevel.Value = GetExperienceRequiredForNextLevel(_level.Value);

            return true;
        }

        private int GetExperienceRequiredForNextLevel(int level)
            => _experienceRequirements[Mathf.Clamp(level - 1, 0, _experienceRequirements.Count - 1)];
    }
}