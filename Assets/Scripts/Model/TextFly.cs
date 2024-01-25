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
        StartAnimation(_textFlyUI.GetTextFly());
    }
    public void InitializationTextFly(Vector3 screenPoint,PoolFlyText poolFlyText,bool isFactorClick)
    {
        transform.position = screenPoint;
        _poolFlyText = poolFlyText;
        _isFactorClick = isFactorClick;
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
