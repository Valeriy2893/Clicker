using System;
using UnityEngine;

public interface ITextFlyView
{
    public GameObject GameObject { get; }
    public void SetColor(Color color);
    public void SetText(string text);
    public void SetFontSize(int size);
    public void StartAnimation();
    public event Action<ITextFlyView> AnimationEnded;
}