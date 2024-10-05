using System;
using R3;
using UnityEngine;

public class R3Ex : MonoBehaviour
{
    private void Start()
    {
        Example1();
    }
    public Observable<int> Health2 => _health;
    public ReadOnlyReactiveProperty<int> Health => _health;
    private readonly ReactiveProperty<int> _health=new ();
    private readonly Subject<int> _health2=new ();
    private IDisposable _disposable;
    private CompositeDisposable _compositeDisposable;
    private void Example1()
    {
        // Health.Subscribe(newValue => Debug.Log(newValue));
        //  _disposable=_health.Subscribe(newValue=> Debug.Log(newValue));
        //  var a = _health.Subscribe(newValue => Debug.Log(newValue));
        // _compositeDisposable.Add(a);
        //
        // Health.Merge(_health2).Where(x=>x.Equals(_health2)).Subscribe(newValue=> Debug.Log(newValue));
        // _health.Value = 100;
        // _health.Value = 90;
        // _health.Value -= 50;
        // _disposable.Dispose();
        // _health.Value += 120;
        //_health.OnNext(10) аналог значения выше
    }
}
