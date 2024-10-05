using R3;
using UnityEngine;

public class Progress
{
    public readonly CompositeDisposable CompositeDisposable=new ();
    public LevelProgression LevelProgression{ get; set; }
    public Wallet Wallet{ get; set; }
    private int CurrentValue { get; set; }
    private int CurrentMaxValue { get; set; }
    public Progress(Player player)
    {
        LevelProgression = new LevelProgression();
        Wallet = new Wallet();
        player.OnClickAnimal += Wallet.AddCoins;
        player.OnClickAnimal += AddCurrentValue;
    }
    private void CheckValue()
    {
        if (CurrentValue < GetMaxValueSlider()) return;
        // OnLevelUp?.Invoke();
        // AddLevel();
        AddMaxValue();
        CurrentValue = 0;
    }
    public int GetMaxValueSlider()
    {
        var minValue = 100;
        CurrentMaxValue = Mathf.Clamp(CurrentMaxValue, minValue, int.MaxValue);
        return CurrentMaxValue;
    }
    
    public void AddCurrentValue()
    {
        CurrentValue++;
        CheckValue();
    }

    private void AddMaxValue()
    {
        var factor = 20;
        var controlNum = 100;
        var defaultNum = 100;
        CurrentMaxValue = CurrentMaxValue <= controlNum ? defaultNum : CurrentMaxValue;
        CurrentMaxValue *= factor;
    }
}
