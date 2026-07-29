using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    Dictionary<int, Skill> skillDic;

    void Awake()
    {
        skillDic = new Dictionary<int, Skill>()
    {
        { 1, GetComponent<Skill_1>() },
        { 2, GetComponent<Skill_2>() },
        { 3, GetComponent<Skill_3>() },
    };

    }

    void Start()
    {
        SkillLevelUp(1); // 기본스킬은 1 갖고 시작.
    }

    public void SkillLevelUp(int n)
    {
        skillDic[n].LevelUp();

        SetTimeScale(0);

        UIManager.Instance.ActiveSkillLevelUpPanel();
    }

    public void SetTimeScale(int n)
    {
        Time.timeScale = n;
    }
}