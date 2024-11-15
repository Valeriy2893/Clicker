using R3;

namespace _Game.Scripts.Model.Abstracts
{
    public interface ILevelProgression
    {
        public ReadOnlyReactiveProperty<int> CurrentLevel { get; }
        public ReadOnlyReactiveProperty<int> Experience { get; }
        public ReadOnlyReactiveProperty<int> ExperienceRequiredForNextLevel { get; }
        public bool TryAddExperience(int experience);
    }
}