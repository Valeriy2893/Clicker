using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    private const string AnimalPath = "AnimalsData/";
    private const string ButtonsPath = "ButtonsData/";

    private Dictionary<string, AnimalsPassport> _animals;
    private Dictionary<TypeButton,ButtonPassport> _buttons;
    
    public static ResourcesManager Instance;
    private void Awake()
    {  
        Instance = this;
        
        _animals = Resources
            .LoadAll<AnimalsPassport>(AnimalPath)
            .ToDictionary(animal => animal.name);
        
        _buttons = Resources
            .LoadAll<ButtonPassport>(ButtonsPath)
            .ToDictionary(buttons => buttons.TypeButton);
    }

    public AnimalsPassport GetAnimalPassport(string nameAnimal) => _animals.GetValueOrDefault(nameAnimal);
    public ButtonPassport GetButtonPassport(TypeButton buttons) => _buttons.GetValueOrDefault(buttons);
    public IReadOnlyCollection<ButtonPassport> GetAllButtonsPassport() => _buttons.Values;
}