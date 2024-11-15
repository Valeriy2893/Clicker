using _Game.Scripts.View.Abstracts;
using UnityEngine;

namespace _Game.Scripts.View
{
    public class FXUI: IFXView
    {
        private ParticleSystem _fXChangeSkin;
        private ParticleSystem _fXClick;

        public void Initialize(ParticleSystem fxClick, ParticleSystem fxChangeSkin)
        {
            _fXClick = fxClick;
            _fXChangeSkin = fxChangeSkin;
        }

        public void PlayClickFX(Vector3 position)
        {
            _fXClick.transform.position = position;
            _fXClick.Play();
        }
    
        public void PlayChangeSkinFX() => _fXChangeSkin.Play();
    }
}