using System;
using System.Collections.Generic;
using _Game.Scripts.Model;
using _Game.Scripts.Model.Config;
using _Game.Scripts.Presenter;
using _Game.Scripts.Presenter.Managers;
using _Game.Scripts.Services;
using _Game.Scripts.Services.Abstract;
using _Game.Scripts.Services.AnimalFactory;
using _Game.Scripts.Services.ButtonFactory;
using _Game.Scripts.View;
using UnityEngine;

namespace _Game.Scripts.MainScript
{
    public class EntryPointGameplay : MonoBehaviour
    {
        [SerializeField] private Transform _parentButtons;
        [SerializeField] private Transform _parentAnimals;
        [SerializeField] private Transform _parentTextFly;
        [SerializeField] private Camera _cameraMain;

        [SerializeField] private CoinsUI _coinsUI;
        [SerializeField] private LevelUI _levelUI;
        [SerializeField] private VolumeUI _volumeUI;

        private EntryPointBootstrap _entryPointBootstrap;
        private readonly List<IDisposable> _disposables = new();

        private DefaultAnimalFactory _animalFactory;
        private DefaultButtonFactory _buttonFactory;
        private PoolFlyText _poolFlyText;
        private ButtonsManager _buttonsManager;
        private IClickHandler _clickHandler;
        private IClickCalculator _clickCalculator;

        private void Awake()
        {
            _entryPointBootstrap = FindObjectOfType<EntryPointBootstrap>();

            InitializeButtonsSystem();
            InitializeCoreSystems();
            InitializeAnimalSystem();
            InitializeUISystem();
            InitializeGameLogic();
        }

        private void InitializeCoreSystems()
        {
            _clickHandler = new ClickHandler(_cameraMain);
            _clickCalculator = new ClickCalculator(_clickHandler, _buttonsManager);
            
            _disposables.Add((IDisposable)_clickHandler);
        }

        private void InitializeButtonsSystem()
        {
            _buttonFactory = new DefaultButtonFactory(
                _entryPointBootstrap.ResourcesManager,
                _parentButtons,
                _entryPointBootstrap.CurrencyProvider
            );

            _buttonsManager = new ButtonsManager(_buttonFactory,  new AutoClickService());
            _disposables.Add(_buttonsManager);
        }

        private void InitializeAnimalSystem()
        {
            _animalFactory = new DefaultAnimalFactory(
                _entryPointBootstrap.ResourcesManager,
                _parentAnimals,
                _clickHandler
            );

            var animalManager = new AnimalManager(
                _entryPointBootstrap.ResourcesManager.GetCountAllAnimal(),
                _entryPointBootstrap.LevelProgression,
                _animalFactory
            );

            _disposables.Add(animalManager);
        }

        private void InitializeUISystem()
        {
            InitializeFlyTextSystem();
            InitializeFXManager();
            InitializeVolumeManager();
        }

        private void InitializeFlyTextSystem()
        {
            _poolFlyText = new PoolFlyText(
                _entryPointBootstrap.ResourcesManager.GetFlyTextPrefab(),
                _parentTextFly,
                new TextFlyInitializer()
            );

            var flyTextManager = new FlyTextManager(
                _poolFlyText,
                _cameraMain,
                _clickCalculator,
                _clickHandler
            );

            _disposables.Add(flyTextManager);
        }

        private void InitializeFXManager()
        {
            var fxManager = new FXManager(
                new FXUI(),
                _clickHandler,
                _entryPointBootstrap.LevelProgression,
                _entryPointBootstrap.ResourcesManager.GetFxPrefab(FxType.ChangeAnimal),
                _entryPointBootstrap.ResourcesManager.GetFxPrefab(FxType.Click)
            );

            _disposables.Add(fxManager);
        }

        private void InitializeVolumeManager()
        {
            var volumeMain = new VolumeMain(
                new VolumeInfo(),
                _volumeUI,
                _entryPointBootstrap.LevelProgression,
                _clickHandler,
                _entryPointBootstrap.ResourcesManager
            );

            _disposables.Add(volumeMain);
        }

        private void InitializeGameLogic()
        {
            var shopping = new Shopping(
                _entryPointBootstrap.CurrencyProvider,
                _coinsUI,
                _clickCalculator,
                _buttonsManager
            );

            var levelManager = new LevelManager(
                _entryPointBootstrap.LevelProgression,
                _levelUI,
                _clickCalculator
            );
            
            _disposables.Add(shopping);
            _disposables.Add(levelManager);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }

            _disposables.Clear();
        }
    }
}
