using System;
using UnityEngine;
using R3;

public class ClickHandler: IClickHandler,IDisposable
{
    private readonly Camera _cameraMain;
    private readonly CompositeDisposable _disposables = new();
    
    public event Action<Vector3> ClickedAnimalWithPosition;
    public event Action ClickedAnimal;
    public ClickHandler(Camera cameraMain)
    {
        _cameraMain = cameraMain;
        Observable.EveryUpdate().Subscribe(_=>UpdateInput()).AddTo(_disposables);
    }
    private void UpdateInput()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        var ray = _cameraMain.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return;
        
        ClickedAnimal?.Invoke();
        ClickedAnimalWithPosition?.Invoke(hit.point);
    }
    public void Dispose()=> _disposables.Dispose();
}