using _Game.Scripts.View.Abstracts;
using UnityEngine;

namespace _Game.Scripts.Services
{
    public class TextFlyInitializer
    {
        private const int FontSizeCrit = 100;
        private const int FontSizeClick = 45;
        private readonly Color _colorCrit=Color.red;
        private readonly Color _colorClick=Color.black;

        public void Initialize(ITextFlyView textFlyUI, Vector3 screenPoint, bool isFactor, int clickValue)
        {
            textFlyUI.SetText("+" + FormatLargeNumber.ModificationInt(clickValue));
            textFlyUI.SetColor(isFactor ? _colorCrit : _colorClick);
            textFlyUI.SetFontSize(isFactor ? FontSizeCrit : FontSizeClick);
            textFlyUI.GameObject.transform.position = screenPoint;
            textFlyUI.StartAnimation();
        }
    }
}