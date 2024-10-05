using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private const int _sceneBuildIndex = 1;

    private void Start()
    {
        SceneManager.LoadScene(_sceneBuildIndex);
    }

}
