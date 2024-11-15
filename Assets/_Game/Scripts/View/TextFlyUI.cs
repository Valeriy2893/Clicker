using System;
using _Game.Scripts.View.Abstracts;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.View
{
    public class TextFlyUI : MonoBehaviour, ITextFlyView
    {
        [field: SerializeField] public TMP_Text TextFly { get; private set; }
        public GameObject GameObject=> gameObject;
        public event Action<ITextFlyView> AnimationEnded;
        public void SetColor(Color color) => TextFly.color = color;
        public void SetText(string text) => TextFly.text = text;
        public void SetFontSize(int size) => TextFly.fontSize = size;
        public void StartAnimation()
        {
            var offset = 150;
            var time = 1;

            var originalPosition = transform.localPosition;
            transform.DOLocalMoveY(transform.localPosition.y + offset, time)
                .OnComplete(() =>
                {
                    transform.localPosition = originalPosition;
                    AnimationEnded?.Invoke(this);
                });
        }
    }
}