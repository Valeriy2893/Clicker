using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter;
using _Game.Scripts.Presenter.Abstracts;
using _Game.Scripts.Services.Abstract;
using _Game.Scripts.View.Abstracts;
using UnityEngine;

namespace _Game.Scripts.Services.AnimalFactory
{
    public class DefaultAnimalFactory: AnimalFactoryBase
    {
        public DefaultAnimalFactory(ResourcesManager resourcesManager, Transform parentButtons, IClickHandler clickHandler) 
            : base(resourcesManager, parentButtons, clickHandler){ }

        public override IAnimalMain CreateAnimal(int index)
        {
            var animalPassport = GetAnimalsPassport(index);
            if (animalPassport == null) return null;

            var animalUI = CreateAnimalUI(animalPassport, ParentAnimal);
            if (animalUI == null) return null;

            var animalMain = new AnimalMain(animalUI, index, animalPassport.AnimationAnimals, ClickHandler);
            
            return animalMain;
        }
        private IAnimalView CreateAnimalUI(AnimalPassport animalPassport, Transform parent)
        {
            var anumalInstance = Object.Instantiate(animalPassport.Prefab, parent);
            return anumalInstance.GetComponent<IAnimalView>();
        }
    }
}