using TMPro;
using UnityEngine;

public class DataUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _allCoins;
    [SerializeField] private TMP_Text _level;

    [SerializeField] private TMP_Text _click;
    [SerializeField] private TMP_Text _factorClick;
    [SerializeField] private TMP_Text _chanceFactorClick;
    [SerializeField] private TMP_Text _clickSec;
    [SerializeField] private TMP_Text _factorClickSec;

    [SerializeField] private Data _data;
    [SerializeField] private ButtonsHandler _buttonsHandler;
    [SerializeField] private NumberFormatter _numberFormatter;

    private void Start()
    {
        ShowClick();
        ShowFactorClick();
        ShowChanceFactorClick();
        ShowClickSec();
        ShowFactorClickSec();
        ShowLevel();
    }
    public void ShowAllCoins()
    {
        _allCoins.text = _numberFormatter.ModificationInt(_data.GetAllCoins());
        _buttonsHandler.DisableButtons();
    }
    public void ShowClick() => _click.text = _numberFormatter.ModificationInt(_data.GetClick());
    public void ShowFactorClick() => _factorClick.text = _numberFormatter.ModificationInt(_data.GetFactorClick());
    public void ShowChanceFactorClick() => _chanceFactorClick.text = _data.GetChanceFactorClick() + "%".ToString();
    public void ShowClickSec() => _clickSec.text = _numberFormatter.ModificationInt(_data.GetClickSec());
    public void ShowFactorClickSec() => _factorClickSec.text = _data.GetFactorClickSec().ToString();
    public void ShowLevel() => _level.text = _data.GetLevel().ToString();
}



