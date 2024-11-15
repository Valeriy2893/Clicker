using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter.Abstracts;
using _Game.Scripts.Services.Abstract;
using UnityEngine;

namespace _Game.Scripts.Services.AnimalFactory
{
    public abstract class AnimalFactoryBase
    {
        protected readonly Transform ParentAnimal;
        protected readonly IClickHandler ClickHandler;
        private readonly ResourcesManager _resourcesManager;
        
        protected AnimalFactoryBase(ResourcesManager resourcesManager, Transform parentButtons,IClickHandler clickHandler)
        {
            _resourcesManager = resourcesManager;
            ParentAnimal = parentButtons;
            ClickHandler = clickHandler;
        }
        
        public abstract IAnimalMain CreateAnimal(int index);
        
        protected AnimalPassport GetAnimalsPassport(int index)
            => _resourcesManager.GetAnimalPassport(index);
    }
}