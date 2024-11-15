using System;

namespace _Game.Scripts.Services.Abstract
{
    public interface IClickCalculator
    {
        public event Action<int, bool> ClickCalculatedWithFactor;
        public event Action<int> ClickCalculated;
    }
}