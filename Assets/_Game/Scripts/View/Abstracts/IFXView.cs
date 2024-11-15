using UnityEngine;

namespace _Game.Scripts.View.Abstracts
{
    public interface IFXView
    {
        public void Initialize(ParticleSystem fxClick, ParticleSystem fxChangeSkin);
        public void PlayClickFX(Vector3 position);
        public void PlayChangeSkinFX();
    }
}
    
