using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalMain: IDisposable
{
    public int Index {get;}
    public GameObject GameObjectAnimal =>_animalView.GameObjectAnimal;
    
    private readonly IAnimalView _animalView;
    private readonly List<AnimationAnimal> _animationAnimal;
    private readonly IClickHandler _clickHandler;
    
    public AnimalMain(IAnimalView animalView,int index,List<AnimationAnimal> animationAnimal,IClickHandler clickHandler)
    {
        _animalView = animalView;
        Index=index;
        _animationAnimal=animationAnimal;
        _clickHandler=clickHandler;
        _clickHandler.ClickedAnimal += PlayAnimation;
    }

    private void PlayAnimation() 
        => _animalView.PlayAnimation(GetCurrentAnimation());

    private string GetCurrentAnimation()
    {
        if (_animationAnimal == null || _animationAnimal.Count == 0) return null;
        
        var minInclusive = 0;
        var animationIndex= Random.Range(minInclusive, _animationAnimal.Count);
        return _animationAnimal[animationIndex].AnimationClip.name;
    }
    
    public void Dispose()=> _clickHandler.ClickedAnimal -= PlayAnimation;
}
