using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneeManager : MonoBehaviour
{
    static SceneeManager instance;
    public static SceneeManager Instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    string mainGame = "MainGame";

    public void LoadMainGame()
    {
        SceneManager.LoadScene(mainGame);
    }

    public void ReloadCurrentScene()
    {
        Scene currentScene =
            SceneManager.GetActiveScene();

        SceneManager.LoadScene(
            currentScene.buildIndex
        );
    }
}
