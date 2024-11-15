using System;
using UnityEngine;

namespace _Game.Scripts.Services.Abstract
{
    public interface IClickHandler
    {
        public event Action<Vector3> ClickedAnimalWithPosition;
        public event Action ClickedAnimal;
    }
}