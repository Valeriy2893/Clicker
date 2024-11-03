using System;
using System.Collections.Generic;
using R3;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class AnimalManager: IDisposable
{
    private AnimalMain _currentAnimalMain;
    private readonly List<AnimalMain> _animalsMain= new();
    private readonly ResourcesManager _resourcesManager;
    private readonly Transform _parentAnimal;
    private readonly CompositeDisposable _disposable = new();
    private readonly IClickHandler _clickHandler;
    public AnimalManager(ResourcesManager resourcesManager, Transform parentAnimal, ILevelProgression levelProgression,IClickHandler clickHandler)
    {
        _resourcesManager = resourcesManager;
        _parentAnimal=parentAnimal;
        _clickHandler= clickHandler;
        levelProgression.CurrentLevel.Subscribe(x => ChangeAnimal()).AddTo(_disposable);
    }
    
    private AnimalMain GetAnimal()
    {
        var count = _resourcesManager.GetCountAllAnimal();

        if (_animalsMain.Count < count)
        {
            var index = 0;
            
            if (_currentAnimalMain!=null)
                index = _currentAnimalMain.Index + 1;
            
            return CreateAnimal(_resourcesManager, _parentAnimal, index);
        }
        
        var minInclusive = 0;
        var valueRandom = Random.Range(minInclusive, _animalsMain.Count);
        return _animalsMain[valueRandom];
    }
    private AnimalMain CreateAnimal(ResourcesManager resourcesManager, Transform parentAnimal, int index)
    {
        var animalPassport = GetAnimalsPassport(resourcesManager,index);
        if (animalPassport == null) return null;
        
        var animalUI = CreateAnimalUI(animalPassport, parentAnimal);
        if (animalUI == null) return null;
        
        var animalMain = new AnimalMain(animalUI,index,animalPassport.AnimationAnimals,_clickHandler);
        _animalsMain.Add(animalMain);

        return animalMain;
    }

    private void ChangeAnimal()
    {
        _currentAnimalMain?.GameObjectAnimal?.SetActive(false);
        _currentAnimalMain = GetAnimal();
        _currentAnimalMain?.GameObjectAnimal?.SetActive(true);
    }
    
    private IAnimalView CreateAnimalUI(AnimalPassport animalPassport, Transform parent)
    {
        var anumalInstance = Object.Instantiate(animalPassport.Prefab, parent);
        return anumalInstance.GetComponent<IAnimalView>();
    }
    private AnimalPassport GetAnimalsPassport(ResourcesManager resourcesManager, int index)
        => resourcesManager.GetAnimalPassport(index);

    public void Dispose()=> _disposable.Dispose();
}
