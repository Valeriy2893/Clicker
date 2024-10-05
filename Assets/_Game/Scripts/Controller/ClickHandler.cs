using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _cameraMain;
    [SerializeField] private Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var ray = _cameraMain.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hit))
        {
            player.OnClick(hit);
        }
    }
}


