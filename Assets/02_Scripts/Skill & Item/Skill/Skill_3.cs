using System.Collections.Generic;
using UnityEngine;

public class Skill_3 : Skill
{
    Transform skillObj;
    List<GameObject> surigums;

    void Awake()
    {
        skillObj = skillData.SkillObj.transform;
        for (int i = 0; i < skillData.SkillObj.transform.childCount; i++)
        {
            surigums.Add(skillObj.GetChild(i).gameObject);
        }
    }

    [SerializeField] float rotateSpeed;
    void Update()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        if (level > 0 && surigums[level - 1].activeSelf == false)
        {
            surigums[level - 1].gameObject.SetActive(true);
        }
        skillObj.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
