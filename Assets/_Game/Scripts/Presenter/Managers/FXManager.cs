using System;
using _Game.Scripts.Model.Abstracts;
using _Game.Scripts.Services.Abstract;
using _Game.Scripts.View.Abstracts;
using R3;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.Presenter.Managers
{
    public class FXManager : IDisposable
    {
        private readonly IFXView _fxView;
        private readonly GameObject _fXChangeSkinPrefab;
        private readonly GameObject _fXClickPrefab;
        private readonly IClickHandler _clickHandler;
        private readonly CompositeDisposable _disposable = new();

        public FXManager(IFXView fxView, IClickHandler clickHandler, ILevelProgression levelProgression,
            GameObject fXChangeSkinPrefab, GameObject fXClickPrefab)
        {
            _fxView = fxView;
            _fXChangeSkinPrefab = fXChangeSkinPrefab;
            _fXClickPrefab = fXClickPrefab;
            _clickHandler = clickHandler;
            clickHandler.ClickedAnimalWithPosition += PlayClickFX;
            levelProgression.CurrentLevel.Skip(1).Subscribe(x => PlayChangeSkinFX()).AddTo(_disposable);
            CreateFX();
        }

        public void Dispose()
        {
            _clickHandler.ClickedAnimalWithPosition -= PlayClickFX;
            _disposable.Dispose();
        }

        private void CreateFX()
        {
            var fxClick = Object.Instantiate(_fXClickPrefab).GetComponent<ParticleSystem>();
            var fxChangeSkin = Object.Instantiate(_fXChangeSkinPrefab).GetComponent<ParticleSystem>();

            _fxView.Initialize(fxClick, fxChangeSkin);
        }

        private void PlayClickFX(Vector3 position) => _fxView.PlayClickFX(position);

        private void PlayChangeSkinFX() => _fxView.PlayChangeSkinFX();
    }
}