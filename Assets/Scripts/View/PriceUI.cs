using TMPro;
using UnityEngine;

public class PriceUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _clickText;
    [SerializeField] private TMP_Text _factorClickText;
    [SerializeField] private TMP_Text _chanceFactorClickText;

    [SerializeField] private TMP_Text _clickSecText;
    [SerializeField] private TMP_Text _factorClickSecText;

    [SerializeField] private Price _price;
    [SerializeField] private NumberFormatter _numberFormatter;

    private void Start()
    {
        ShowPriceClick();
        ShowPriceFactorClick();
        ShowPriceChanceFactorClick();
        ShowPriceClickSec();
        ShowPriceFactorClickSec();
    }
    public void ShowPriceClick() => _clickText.text = _numberFormatter.ModificationInt(_price.GetPriceClick());
    public void ShowPriceFactorClick() => _factorClickText.text = _numberFormatter.ModificationInt(_price.GetPriceFactorClick());
    public void ShowPriceChanceFactorClick() => _chanceFactorClickText.text = _numberFormatter.ModificationInt(_price.GetPriceChanceFactorClick());
    public void ShowPriceClickSec() => _clickSecText.text = _numberFormatter.ModificationInt(_price.GetPriceClickSec());
    public void ShowPriceFactorClickSec() => _factorClickSecText.text = _numberFormatter.ModificationInt(_price.GetPriceFactorClickSec());
}


