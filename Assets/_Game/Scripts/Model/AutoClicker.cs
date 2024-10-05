using System.Collections;
using UnityEngine;
public class AutoClicker : MonoBehaviour
{
    [SerializeField] private DataUI _dataUI;
    [SerializeField] private Data _data;
    [SerializeField] private Player clickHandler;
    private IEnumerator Start()
    {
        clickHandler = FindObjectOfType<Player>();
        _data = clickHandler.Data;
        var secondsWait = 1;

        while (true)
        {
            // _dataUI.ShowAllCoins();

            yield return new WaitForSeconds(secondsWait);
            _data.ApplyMultiplicationFactorClickSec();

        }
    }

}




