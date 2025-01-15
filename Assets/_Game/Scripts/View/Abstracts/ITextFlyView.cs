using System;
using UnityEngine;

namespace _Game.Scripts.View.Abstracts
{
    public interface ITextFlyView
    {
        public GameObject GameObject { get; }
        public event Action<ITextFlyView> AnimationEnded;
        public void SetColor(Color color);
        public void SetText(string text);
        public void SetFontSize(int size);
        public void StartAnimation();
    }
}