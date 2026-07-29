using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text restartText;
    [SerializeField] TMP_Text surviveTimerText;
    float surviveTimer_Float;
    int surviveTimer_Int;

    void Awake()
    {
        restartText.gameObject.SetActive(false);
    }

    void Start()
    {
        GameManager.Instance.OnGameOver += () => restartText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        SetSurviveTimerText();
    }

    void SetSurviveTimerText()
    {
        surviveTimer_Float += Time.deltaTime;
        Debug.Log(surviveTimer_Float);
        if (surviveTimer_Int != (int)surviveTimer_Float)
        {
            surviveTimer_Int = (int)surviveTimer_Float;
            surviveTimerText.text = $"survive time : {surviveTimer_Int}";
        }
    }
}
