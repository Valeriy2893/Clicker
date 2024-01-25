using System.Collections.Generic;
using UnityEngine;
public class PoolFlyText : MonoBehaviour
{
    [SerializeField] private GameObject _prefabFlyText;

    private GameObject _currentTextFly;

    private List<GameObject> _FreeFlyText = new();

    public GameObject GetFlyText()
    {
        if (IsListEmpty())
        {
            return Spawn();
        }
        else
        {
            return GetTextFromList();
        }
    }
    public void ReturnFlyText(GameObject FlyText)
    {
        _FreeFlyText.Add(FlyText);
        FlyText.SetActive(false);
    }

    private GameObject GetTextFromList()
    {
        _currentTextFly = _FreeFlyText[0];

        _currentTextFly.SetActive(true);

        _FreeFlyText.Remove(_currentTextFly);

        return _currentTextFly;
    }
    private bool IsListEmpty()
    {
        return _FreeFlyText.Count == 0;
    }

    private GameObject Spawn()
    {
        return Instantiate(_prefabFlyText, transform);
    }
}
