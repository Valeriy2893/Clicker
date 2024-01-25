using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _cameraMain;

    [SerializeField] private Audio _audio;
    [SerializeField] private FXClick _fxClick;
    [SerializeField] private SkinSpawner _spawner;

    [SerializeField] private PoolFlyText _poolFlyText;

    [SerializeField] private Data _data;
    [SerializeField] private DataUI _dataUI;
    [SerializeField] private SliderLevel _sliderUI;
    private void Update()
    {
        HandleMouseClick();
    }

    private void HandleMouseClick()
    {
        var button = 0;
        if (Input.GetMouseButtonDown(button))
        {
            Ray ray = _cameraMain.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var isFactorClick = _data.IsFactorClick();

                GiveDataForTextFly(hit, isFactorClick);

                _sliderUI.AddValueSlider(isFactorClick);
                _spawner.GetCurrentAnimationPlayer().PlayAnimation();
                _audio.PlayClick();
                _fxClick.SetPositionFX(hit);
                _data.TryApplyMultiplicationFactorClick(isFactorClick);
            }
        }
    }

    private void GiveDataForTextFly(RaycastHit hit, bool isFactor)
    {
        var _currentText = _poolFlyText.GetFlyText();
        _currentText.GetComponent<TextFly>().InitializationTextFly(DisableZCoordinate(hit), _poolFlyText, isFactor);
    }

    private Vector3 DisableZCoordinate(RaycastHit hit)
    {
        var offset = 10f;
        Vector3 screenPoint = _cameraMain.WorldToScreenPoint(hit.point);
        var zCoordinate = 0f;
        screenPoint = new Vector3(screenPoint.x, screenPoint.y + offset, zCoordinate);
        return screenPoint;
    }
}


