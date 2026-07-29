using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    static public GameManager Instance => instance;

    public bool IsGameOver { get; set; }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
