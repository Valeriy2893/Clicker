using System;
using System.Collections.Generic;
using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Presenter.Abstracts;
using _Game.Scripts.Services.AnimalFactory;
using R3;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Presenter.Managers
{
    public class AnimalManager : IDisposable
    {
        private IAnimalMain _currentAnimalMain;
        private readonly List<IAnimalMain> _animalsMain = new();
        private readonly CompositeDisposable _disposable = new();
        private readonly AnimalFactoryBase _animalFactoryBase;
        private readonly int _countAnimal;
        public AnimalManager(int countAnimal, ILevelProgression levelProgression, AnimalFactoryBase animalFactoryBase)
        {
            _animalFactoryBase = animalFactoryBase;
            _countAnimal = countAnimal;
            levelProgression.CurrentLevel.Subscribe(x => ChangeAnimal()).AddTo(_disposable);
        }

        private IAnimalMain GetAnimal()
        {
            if (_animalsMain.Count < _countAnimal)
            {
                var index = 0;

                if (_currentAnimalMain != null)
                    index = _currentAnimalMain.Index + 1;

                var instanceAnimalMain= _animalFactoryBase.CreateAnimal(index);
                _animalsMain.Add(instanceAnimalMain);
                return instanceAnimalMain;
            }

            var minInclusive = 0;
            var valueRandom = Random.Range(minInclusive, _animalsMain.Count);
            return _animalsMain[valueRandom];
        }
        
        private void ChangeAnimal()
        {
            _currentAnimalMain?.GameObjectAnimal?.SetActive(false);
            _currentAnimalMain = GetAnimal();
            _currentAnimalMain?.GameObjectAnimal?.SetActive(true);
        }
        
        public void Dispose() => _disposable.Dispose();
    }
}
