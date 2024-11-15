using System;
using _Game.Scripts.Model.Config;
using R3;

namespace _Game.Scripts.Presenter.Abstracts
{
    public interface IButtonMain
    {
        public ReadOnlyReactiveProperty<int> Value { get; }
        public TypeButton TypeButton { get; }
        
        public event Func<int, bool> ClickedButtonMain;
    }
}
