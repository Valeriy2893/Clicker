using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextFly : MonoBehaviour
{
    [SerializeField] private TextFlyUI _textFlyUI;

    private PoolFlyText _poolFlyText;
    private bool _isFactorClick;
    private void OnEnable()
    {
        _textFlyUI.SelectColor(_isFactorClick);
        _textFlyUI.SelectFontSize(_isFactorClick);
        _textFlyUI.ShowTextFly(_isFactorClick);
        StartAnimation(_textFlyUI.TextFly);
    }
    public void InitializationTextFly(RaycastHit hit, PoolFlyText poolFlyText, bool isFactorClick)
    {
        transform.position = DisableZCoordinate(hit);
        _poolFlyText = poolFlyText;
        _isFactorClick = isFactorClick;
    }
    private Vector3 DisableZCoordinate(RaycastHit hit)
    {
        var offset = 10f;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(hit.point);
        var zCoordinate = 0f;
        screenPoint = new Vector3(screenPoint.x, screenPoint.y + offset, zCoordinate);
        return screenPoint;
    }
    private void StartAnimation(TMP_Text tMP_Text)
    {
        var offset = 150;
        var time = 1;

        Vector3 originalPosition = transform.localPosition;
        transform.DOLocalMoveY(transform.localPosition.y + offset, time)
        .OnComplete(() =>
        {
            _poolFlyText.ReturnFlyText(tMP_Text.gameObject);
            transform.localPosition = originalPosition;
        });
    }
}
