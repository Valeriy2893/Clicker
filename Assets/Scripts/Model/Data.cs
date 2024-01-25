using UnityEngine;

public class Data : MonoBehaviour
{
    private int _allCoins;

    private int _click;
    private int _clickSec;
    private int _factorClick;
    private int _chanceFactorClick;
    private int _factorClickSec;

    private int _maxValueSlider;
    private int _level;

    private int _controlNum = 0;
    private int _defaultNum = 1;
    public bool IsFactorClick()
    {
        var minInclusive = 1;
        var maxExclusive = 101;
        return Random.Range(minInclusive, maxExclusive) <= GetChanceFactorClick();
    }
    public int GetLevel()
    {
        return GetValid(_level, _controlNum, _defaultNum);
    }
    public int GetMaxValueSlider()
    {
        var minValue = 100;
        _maxValueSlider = Mathf.Clamp(_maxValueSlider, minValue, int.MaxValue);
        return _maxValueSlider;
    }
    public int GetAllCoins()
    {
        return _allCoins;
    }
    public int GetClick()
    {
        return GetValid(_click, _controlNum, _defaultNum);
    }
    public int GetFactorClick()
    {
        return GetValid(_factorClick, _controlNum, _defaultNum);
    }
    public int GetChanceFactorClick()
    {
        return GetValid(_chanceFactorClick, _controlNum, _defaultNum);
    }
    public int GetClickSec()
    {
        return _clickSec;
    }
    public int GetFactorClickSec()
    {
        return GetValid(_factorClickSec, _controlNum, _defaultNum);
    }
    public void TryApplyMultiplicationFactorClick(bool isFactor)
    {
        if (isFactor)
        {
            AddCoins(GetClick() * GetFactorClick());
        }
        else
        {
            AddCoins(GetClick());
        }
    }
    public void ApplyMultiplicationFactorClickSec()
    {
        AddCoins(GetClickSec() * GetFactorClickSec());
    }
    public void AddLevel()
    {
        _level = GetValid(_level, _controlNum, _defaultNum);
        _level++;
    }
    public void AddMaxValueSlider()
    {
        var factor = 20;
        var controlNum = 100;
        var DefaultNum = 100;

        _maxValueSlider = GetValid(_maxValueSlider, controlNum, DefaultNum);
        _maxValueSlider *= factor;
    }
    public void AddClick()
    {
        _click = GetValid(_click, _controlNum, _defaultNum);
        _click++;
    }
    public void AddFactorClick()
    {
        _factorClick = GetValid(_factorClick, _controlNum, _defaultNum);
        _factorClick++;
    }
    public void AddChanceFactorClick()
    {
        _chanceFactorClick = GetValid(_chanceFactorClick, _controlNum, _defaultNum);
        _chanceFactorClick++;
    }
    public void AddClickSec()
    {
        _clickSec++;
    }
    public void AddFactorClickSec()
    {
        _factorClickSec = GetValid(_factorClickSec, _controlNum, _defaultNum);
        _factorClickSec++;
    }
    public bool TryRemoveCoins(int amount)
    {
        if (_allCoins >= amount)
        {
            _allCoins -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void AddCoins(int amount)
    {
        _allCoins += amount;
    }
    private int GetValid(int value, int controlNum, int defaultNum)
    {
        if (value <= controlNum)
        {
            return defaultNum;
        }
        else
        {
            return value;
        }
    }

}
