using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerButtons : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private Player _player;

    public Dictionary<TypeButton,ButtonForShop> _buttons = new();

    private void Start()
    {
        _player = FindObjectOfType<Player>();

        var sortedButtons = SortButtons();

        foreach (var item in sortedButtons)
        {
            var button = Instantiate(item.Prefab, parent).GetComponent<ButtonForShop>();
            button.Init(item, _player);
            _buttons.Add(item.TypeButton, button);
        }
    }
    private List<ButtonPassport> SortButtons()
    {
        return ResourcesManager.Instance.GetAllButtonsPassport()
                                                 .OrderBy(item => item.Order)
                                                 .ToList();
    }
}
