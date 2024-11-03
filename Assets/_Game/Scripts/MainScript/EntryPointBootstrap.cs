using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPointBootstrap: MonoBehaviour
{
    private const int SceneBuildIndex = 1;
    public ResourcesManager ResourcesManager{get; private set;}
    public ICurrencyProvider CurrencyProvider{get; private set;}
    public ILevelProgression LevelProgression{get; private set;}
    private IEnumerator Start()
    {
       ResourcesManager = new ResourcesManager();
       CurrencyProvider = new Wallet();
       LevelProgression = new LevelProgression(ResourcesManager.GetExperienceRequiredForNextLevel(),1,0);
     
        DontDestroyOnLoad(gameObject);
        
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneBuildIndex);
    }
}

