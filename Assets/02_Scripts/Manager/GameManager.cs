using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    static public GameManager Instance => instance;

    public Action OnGameOver;
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

    void Start()
    {
        OnGameOver += () => IsGameOver = true;
        OnGameOver += () => Time.timeScale = 0;
    }
}
