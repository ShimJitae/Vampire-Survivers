using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected SkillData skillData;

    protected int level;
    protected int maxLevel;
    protected float coolTime, coolTimer;

    void Awake()
    {
        level = 0;
        maxLevel = skillData.MaxLevel;
    }

    public void LevelUp()
    {
        if (maxLevel <= level)
        {
            return;
        }
        level++;
    }

    public void ReduceCoolTime(float deltaTime)
    {
        coolTimer -= deltaTime;
        if (coolTimer <= 0)
        {
            coolTimer = coolTime;
        }
    }

    public abstract void UseSkill();
}
