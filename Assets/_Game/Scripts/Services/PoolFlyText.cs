using _Game.Scripts.View.Abstracts;
using UnityEngine;
using UnityEngine.Pool;

namespace _Game.Scripts.Services
{
    public class PoolFlyText
    {
        private readonly GameObject _prefabFlyText;
        private readonly Transform _parentPrefabFlyText;
        private readonly ObjectPool<ITextFlyView> _objectPool;
        private readonly TextFlyInitializer _textFlyInitializer;

        public PoolFlyText(GameObject prefabFlyText, Transform parentPrefabFlyText,
            TextFlyInitializer textFlyInitializer)
        {
            _prefabFlyText = prefabFlyText;
            _parentPrefabFlyText = parentPrefabFlyText;
            _textFlyInitializer = textFlyInitializer;

            _objectPool = new ObjectPool<ITextFlyView>(
                CreateFlyTextInstance,
                OnGetFromPool,
                OnReturnToPool,
                OnDestroyInstance,
                false,
                10,
                50
            );
        }

        public void RequestFlyText(Vector3 screenPoint, bool isFactor, int clickValue)
        {
            var textFlyUI = _objectPool.Get();
            if (textFlyUI == null) return;
            _textFlyInitializer.Initialize(textFlyUI, screenPoint, isFactor, clickValue);
        }

        private ITextFlyView CreateFlyTextInstance()
        {
            var instance = Object.Instantiate(_prefabFlyText, _parentPrefabFlyText);

            var textFlyUI = instance.GetComponent<ITextFlyView>();
            textFlyUI.AnimationEnded += flyText => _objectPool.Release(flyText);
            return textFlyUI;
        }

        private void OnGetFromPool(ITextFlyView textFlyUI) => textFlyUI.GameObject.SetActive(true);
        private void OnReturnToPool(ITextFlyView textFlyUI) => textFlyUI.GameObject.SetActive(false);
        private void OnDestroyInstance(ITextFlyView textFlyUI) => Object.Destroy(textFlyUI.GameObject);
    }
}