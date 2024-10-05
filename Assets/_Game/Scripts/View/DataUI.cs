using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DataUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _allCoins;
    [SerializeField] private TMP_Text _level;

    [FormerlySerializedAs("animal")] [SerializeField] private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        // animal.AnimalProgress.OnLevelUp += ShowLevel;
        // // clickModel.OnClickAnimal += ShowAllCoins;
        // animal.AnimalProgress.AllCoins.Subscribe(newValue => _allCoins.text=newValue.ToString()).AddTo(animal.AnimalProgress.CompositeDisposable);
        ShowLevel();
    }
    public void ShowAllCoins()
    {
        // _allCoins.text = FormatLargeNumber.ModificationInt(animal.AnimalProgress.AllCoins.CurrentValue);
    }
    private void ShowLevel()
    {
        // _level.text = animal.AnimalProgress.Level.ToString();
    }

    private void OnDestroy()
    {
        // animal.AnimalProgress.OnLevelUp -= ShowLevel;
        // clickModel.OnClickAnimal -= ShowAllCoins;
    }

    private void OnDisable()
    {
        player.Progress.CompositeDisposable.Dispose();
    }
}



