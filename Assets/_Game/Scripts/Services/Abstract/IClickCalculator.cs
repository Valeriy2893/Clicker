using System;

public interface IClickCalculator
{
    public event Action<int, bool> ClickCalculatedWithFactor;
    public event Action<int> ClickCalculated;
}