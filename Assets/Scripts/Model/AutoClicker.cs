using System.Collections;
using UnityEngine;
public class AutoClicker : MonoBehaviour
{
    [SerializeField] private DataUI _dataUI;
    [SerializeField] private Data _data;
    private IEnumerator Start()
    {
        var secondsWait = 1;

        while (true)
        {
            _dataUI.ShowAllCoins();

            yield return new WaitForSeconds(secondsWait);
            _data.ApplyMultiplicationFactorClickSec();
           
        }
    }
  
}




