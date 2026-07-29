using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    Dictionary<SkillEnum, Skill> skillDic = new Dictionary<SkillEnum, Skill>()
    {
        { SkillEnum.Skill_1, new Skill_1() },
        { SkillEnum.Skill_2, new Skill_2() },
        { SkillEnum.Skill_3, new Skill_3() },
    };

    void Awake()
    {
    }

    public void SkillLevelUp(SkillEnum se)
    {

    }
}

public enum SkillEnum
{
    Skill_1,
    Skill_2,
    Skill_3,
}