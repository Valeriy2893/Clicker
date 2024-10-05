using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public bool CurrentFactorClick { get; private set; }

    
    private readonly Player clickHandler;
    public Data(Player clickHandler, SpawnerAnimals spawnerAnimals)
    {
        this.clickHandler = clickHandler;
        clickHandler.OnClickAnimal += TryApplyMultiplicationFactorClick; //  ����� ��� �������

        // InitValue();
    }

    
    // public int GetValue(TypeButton typeButton)
    // {
    //     return _amount[typeButton];
    // }

    public void AddValue(TypeButton typeButton)
    {
        // if (_amount.ContainsKey(typeButton))
        // {
        //     _amount[typeButton]++;
        //
        //     Validate(typeButton);
        //
        //     /// ��������
        //     var buttons = Object.FindObjectOfType<SpawnerButtons>().GetAllButtons();
        //     foreach (var item in buttons)
        //     {
        //         if (item.TypeButton == typeButton)
        //         {
        //             item.UpdateTextAmount(_amount[typeButton]);
        //         }
        //     }
        //
        //     clickHandler.Price.AddPrice(typeButton);
        // }
    }
    private void Validate(TypeButton typeButton)
    {
        // if (_amount[typeButton] <= 0)
        // {
        //     _amount[typeButton] = 1;
        // }
    }



    //public bool IsFactorClick()
    //{
    //    var minInclusive = 1;
    //    var maxExclusive = 101;

    //    CurrentFactorClick = Random.Range(minInclusive, maxExclusive) <= GetChanceFactorClick();
    //    return CurrentFactorClick;
    //}

    public void TryApplyMultiplicationFactorClick()
    {
        //if (CurrentFactorClick)
        //{
        //    AddCoins(GetValue(TypeButton.Click) * GetValue(TypeButton.FactorClick));
        //}
        //else
        //{
        //    AddCoins(GetValue(TypeButton.Click));
        //}
    }
    public void ApplyMultiplicationFactorClickSec()
    {
        //AddCoins(GetValue(TypeButton.ClickSec) * GetValue(TypeButton.FactorClickSec));
    }

}
