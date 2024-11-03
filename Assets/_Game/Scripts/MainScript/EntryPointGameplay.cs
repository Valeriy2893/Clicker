using UnityEngine;

public class EntryPointGameplay: MonoBehaviour
{
    [SerializeField] private Transform _parentButtons;
    [SerializeField] private Transform _parentAnimals;
    [SerializeField] private Transform _parentTextFly;
    [SerializeField] private Camera _cameraMain;
    
    [SerializeField] private CoinsUI _coinsUI;
    [SerializeField] private LevelUI _levelUI;
    [SerializeField] private VolumeUI _volumeUI;
    
    private EntryPointBootstrap _entryPointBootstrap;
    private void Awake()
    {
       _entryPointBootstrap = FindObjectOfType<EntryPointBootstrap>();
       
       var spawnerButtons = new SpawnerButtons(_entryPointBootstrap.ResourcesManager, _parentButtons,_entryPointBootstrap.CurrencyProvider);
       var buttonsManager  = new ButtonsManager(spawnerButtons,new AutoClickService());
       
       IClickHandler clickHandler = new ClickHandler(_cameraMain);
       IClickCalculator clickCalculator = new ClickCalculator(clickHandler,buttonsManager);
       
       var shopping = new Shopping(_entryPointBootstrap.CurrencyProvider,_coinsUI, clickCalculator,buttonsManager);
       var levelManager = new LevelManager(_entryPointBootstrap.LevelProgression,_levelUI, clickCalculator);
       var managerAnimals = new AnimalManager(_entryPointBootstrap.ResourcesManager,_parentAnimals,_entryPointBootstrap.LevelProgression,clickHandler);
       
       var fxManager = new FXManager(new FXUI(), clickHandler,_entryPointBootstrap.LevelProgression,_entryPointBootstrap.ResourcesManager.GetFxPrefab(FxType.ChangeAnimal),
           _entryPointBootstrap.ResourcesManager.GetFxPrefab(FxType.Click));
       var volumeMain = new VolumeMain(new VolumeInfo(),_volumeUI,_entryPointBootstrap.LevelProgression,clickHandler,_entryPointBootstrap.ResourcesManager);
       var poolFlyText = new PoolFlyText(_entryPointBootstrap.ResourcesManager.GetFlyTextPrefab(), _parentTextFly,new TextFlyInitializer());
       var flyTextService= new FlyTextManager(poolFlyText,_cameraMain,clickCalculator,clickHandler);
    }
}
