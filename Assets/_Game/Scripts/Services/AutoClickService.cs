using System;
using _Game.Scripts.Presenter;
using _Game.Scripts.Presenter.Abstracts;
using R3;

namespace _Game.Scripts.Services
{
    public class AutoClickService : IDisposable
    {
        private readonly CompositeDisposable _disposable = new();

        public event Action<int, int> AddedCoinsAuto;

        public void Initialize(IButtonMain clickSecButton, IButtonMain factorClickSecButton)
        {
            clickSecButton.Value
                .Where(value => value > 0)
                .Take(1)
                .Subscribe(_
                    => StartAutoClick(clickSecButton, factorClickSecButton))
                .AddTo(_disposable);
        }

        public void Dispose() => _disposable.Dispose();

        private void StartAutoClick(IButtonMain clickSecButton, IButtonMain factorClickSecButton)
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ =>
                    AddedCoinsAuto?.Invoke(clickSecButton.Value.CurrentValue, factorClickSecButton.Value.CurrentValue))
                .AddTo(_disposable);
        }
    }
}