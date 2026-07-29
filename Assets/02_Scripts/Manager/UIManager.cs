using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    static public UIManager Instance => instance;

    public TMP_Text LevelText; // playersetting에서 텍스트 빠굼
    [SerializeField] TMP_Text puaseText;
    [SerializeField] TMP_Text restartText;
    [SerializeField] TMP_Text surviveTimerText;
    float surviveTimer_Float;
    int surviveTimer_Int;

    [SerializeField] Slider hpSlider;
    [SerializeField] Slider expSlider;

    [SerializeField] GameObject skillLevelUpPanel;

    public bool IsGameOver { get; set; }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

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

    public void SetSliderValue(SliderEnum se, float value)
    {
        switch (se)
        {
            case SliderEnum.HP:
                hpSlider.value = value;
                break;
            case SliderEnum.EXP:
                expSlider.value = value;
                break;
        }
    }

    public void ActiveSkillLevelUpPanel()
    {

    }
}

public enum SliderEnum
{
    HP,
    EXP
}
