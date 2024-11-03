using System;
using UnityEngine;

public interface IClickHandler
{
    public event Action<Vector3> ClickedAnimalWithPosition;
    public event Action ClickedAnimal;
}