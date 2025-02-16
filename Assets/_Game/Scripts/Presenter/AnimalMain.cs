using System.Collections.Generic;
using _Game.Scripts.Presenter.Abstracts;
using _Game.Scripts.Services.Abstract;
using _Game.Scripts.View.Abstracts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Presenter
{
    public class AnimalMain : IAnimalMain
    {
        private readonly IAnimalView _animalView;
        private readonly List<AnimationClip> _animationAnimal;
        private readonly IClickHandler _clickHandler;

        public int Index { get; }
        public GameObject GameObjectAnimal => _animalView.GameObjectAnimal;

        public AnimalMain(IAnimalView animalView, int index, List<AnimationClip> animationAnimal,
            IClickHandler clickHandler)
        {
            _animalView = animalView;
            Index = index;
            _animationAnimal = animationAnimal;
            _clickHandler = clickHandler;
        }

        public void ClickTracking() => _clickHandler.ClickedAnimal += PlayAnimation;

        public void Dispose() => _clickHandler.ClickedAnimal -= PlayAnimation;

        private void PlayAnimation() => _animalView?.PlayAnimation(GetCurrentAnimation());

        private string GetCurrentAnimation()
        {
            if (_animationAnimal == null || _animationAnimal.Count == 0) return null;

            var minInclusive = 0;
            var animationIndex = Random.Range(minInclusive, _animationAnimal.Count);
            return _animationAnimal[animationIndex].name;
        }
    }
}