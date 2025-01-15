using System;
using _Game.Scripts.Services;
using _Game.Scripts.Services.Abstract;
using UnityEngine;

namespace _Game.Scripts.Presenter.Managers
{
    public class FlyTextManager : IDisposable
    {
        private readonly IClickCalculator _clickCalculator;
        private readonly IClickHandler _clickHandler;
        private readonly PoolFlyText _poolFlyText;
        private readonly Camera _camera;

        private Vector3 _currentPosition;
        private bool _isCurrentFactor;
        private int _currentValue;

        public FlyTextManager(PoolFlyText poolFlyText, Camera camera, IClickCalculator clickCalculator,
            IClickHandler clickHandler)
        {
            _poolFlyText = poolFlyText;
            _camera = camera;
            _clickCalculator = clickCalculator;
            _clickHandler = clickHandler;
            _clickHandler.ClickedAnimalWithPosition += GetCurrentPosition;
            _clickCalculator.ClickCalculatedWithFactor += OnClickWithFactor;
        }

        public void Dispose()
        {
            _clickHandler.ClickedAnimalWithPosition -= GetCurrentPosition;
            _clickCalculator.ClickCalculatedWithFactor -= OnClickWithFactor;
        }

        private void GetCurrentPosition(Vector3 position) => _currentPosition = position;

        private void OnClickWithFactor(int clickValue, bool isFactorActive)
            => ShowFlyText(_currentPosition, isFactorActive, clickValue);

        private void ShowFlyText(Vector3 worldPosition, bool isFactorActive, int clickValue)
        {
            var screenPosition = ConvertToScreenPosition(worldPosition);
            _poolFlyText.RequestFlyText(screenPosition, isFactorActive, clickValue);
        }

        private Vector3 ConvertToScreenPosition(Vector3 worldPosition)
        {
            var offset = 10f;
            var screenPoint = _camera.WorldToScreenPoint(worldPosition);
            return new Vector3(screenPoint.x, screenPoint.y + offset, 0);
        }
    }
}