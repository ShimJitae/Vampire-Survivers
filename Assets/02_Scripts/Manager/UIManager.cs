using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text puaseText;
    [SerializeField] TMP_Text restartText;
    [SerializeField] TMP_Text surviveTimerText;
    float surviveTimer_Float;
    int surviveTimer_Int;

    void Awake()
    {
        restartText.gameObject.SetActive(false);
        puaseText.gameObject.SetActive(false);
    }

    void Start()
    {
        GameManager.Instance.OnGameOver += () => restartText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        Puase();
        SetSurviveTimerText();
    }

    void SetSurviveTimerText()
    {
        surviveTimer_Float += Time.deltaTime;
        if (surviveTimer_Int != (int)surviveTimer_Float)
        {
            surviveTimer_Int = (int)surviveTimer_Float;
            surviveTimerText.text = $"survive time : {surviveTimer_Int}";
        }
    }

    void Puase()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (puaseText.gameObject.activeSelf)
            {
                Time.timeScale = 1;
                puaseText.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                puaseText.gameObject.SetActive(true);
            }
        }
    }
}
