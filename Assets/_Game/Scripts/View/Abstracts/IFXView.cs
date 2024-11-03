using UnityEngine;

public interface IFXView
{
    public void Initialize(ParticleSystem fxClick, ParticleSystem fxChangeSkin);
    public void PlayClickFX(Vector3 position);
    public void PlayChangeSkinFX();
}
    
