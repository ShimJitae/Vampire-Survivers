using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private SkillData skillData;

    int level;

    void Awake()
    {
        level = 0;
    }

    public void LevelUp()
    {
        level++;
    }
}
