using System;
using R3;

public class LevelProgression
{ 
    public ReadOnlyReactiveProperty<int> Level => _level;
    
    private readonly ReactiveProperty<int> _level= new(1);
    
    public void AddLevel()
    {
        _level.Value++;
    }   
}
