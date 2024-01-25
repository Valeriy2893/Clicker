using UnityEngine;

public class NumberFormatter : MonoBehaviour
{
    private int _K = 1000;
    private int _M = 1_000_000;
    private int _B = 1_000_000_000;

    public string ModificationInt(int integer)
    {
        string displayText = integer.ToString();

        if (integer >= _B)
        {
            displayText = (integer / _B) + "." + ((integer % _B) / (_B / 10)).ToString() + " B";
        }
        else if (integer >= _M)
        {
            displayText = (integer / _M) + "." + ((integer % _M) / (_M / 10)).ToString() + "M";
        }
        else if (integer >= _K)
        {
            displayText = (integer / _K) + "." + ((integer % _K) / (_K / 10)).ToString() + "K";
        }
        return displayText;
    }

}

