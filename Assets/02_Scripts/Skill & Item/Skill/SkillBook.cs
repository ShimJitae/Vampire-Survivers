using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    Dictionary<SkillEnum, Skill> skillDic;

    void Awake()
    {
        skillDic = new Dictionary<SkillEnum, Skill>()
    {
        { SkillEnum.Skill_1, GetComponent<Skill_1>() },
        { SkillEnum.Skill_2, GetComponent<Skill_2>() },
        { SkillEnum.Skill_3, GetComponent<Skill_3>() },
    };

        SkillLevelUp(SkillEnum.Skill_1); // 기본스킬은 1 갖고 시작.
    }

    public void SkillLevelUp(SkillEnum se)
    {
        skillDic[se].LevelUp();
    }
}

public enum SkillEnum
{
    Skill_1,
    Skill_2,
    Skill_3,
}