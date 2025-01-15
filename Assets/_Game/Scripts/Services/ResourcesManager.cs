using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Model.Config;
using UnityEngine;
using AudioType = _Game.Scripts.Model.Config.AudioType;

namespace _Game.Scripts.Services
{
    public class ResourcesManager
    {
        private const string AnimalPath = "AnimalsData/";
        private const string ButtonsPath = "ButtonsData/";
        private const string ConfigGame = "ConfigGame";

        private readonly List<AnimalPassport> _animals;
        private readonly List<ButtonPassport> _buttons;
        private readonly List<int> _experienceRequiredForNextLevelConfig;
        private readonly Dictionary<IconType, Sprite> _spritesVolume;
        private readonly Dictionary<AudioType, AudioClip> _audioVolume;
        private readonly Dictionary<FxType, GameObject> _fxGameObjects;
        private readonly GameObject _flyTextGameObject;

        public ResourcesManager()
        {
            _animals = Resources
                .LoadAll<AnimalPassport>(AnimalPath).ToList();

            _buttons = Resources
                .LoadAll<ButtonPassport>(ButtonsPath)
                .ToList();

            var configGame = Resources
                .Load<ConfigGame>(ConfigGame);

            _experienceRequiredForNextLevelConfig = configGame.ExperienceRequiredForNextLevel
                .ToList();

            _spritesVolume =
                configGame.IconVolumes.ToDictionary(iconVolume => iconVolume.Type, iconVolume => iconVolume.Icon);

            _audioVolume =
                configGame.AudioVolumes.ToDictionary(iconVolume => iconVolume.Type, iconVolume => iconVolume.Sound);
            _fxGameObjects = configGame.FxPrefabs.ToDictionary(fx => fx.Type, fx => fx.PrefabParticle);
            _flyTextGameObject = configGame.FlyTextPrefab;
        }

        public GameObject GetFlyTextPrefab() => _flyTextGameObject;

        public AnimalPassport GetAnimalPassport(int index)
        {
            if (_animals.Count == 0 || index < 0) return null;

            return _animals[index % _animals.Count];
        }

        public int GetCountAllAnimal() => _animals.Count;
        public IReadOnlyCollection<ButtonPassport> GetAllButtonsPassport() => _buttons;
        public IReadOnlyList<int> GetExperienceRequiredForNextLevel() => _experienceRequiredForNextLevelConfig;
        public AudioClip GetAudioClipVolume(AudioType type) => _audioVolume.GetValueOrDefault(type);
        public GameObject GetFxPrefab(FxType type) => _fxGameObjects.GetValueOrDefault(type);
        public Sprite GetSpriteVolume(IconType type) => _spritesVolume.GetValueOrDefault(type);
    }
}