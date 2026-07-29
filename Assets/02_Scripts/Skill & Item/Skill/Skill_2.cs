using System.Collections;
using UnityEngine;

public class Skill_2 : Skill
{
    [SerializeField] PlayerSetting ps;
    GameObject bullet;

    void Awake()
    {
        bullet = skillData.SkillObj;
    }

    public override void UseSkill()
    {
        if (level <= 0)
            return;
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }


    Vector2 direction;
    IEnumerator Shoot()
    {
        if (level <= 0)
        {
            yield return new WaitForSeconds(2.5f);
        }

        yield return new WaitForSeconds(skillData.ValuesByLevel[level]);

        if (ps.NearestEnemy == null)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = (ps.NearestEnemy.position - transform.position).normalized;
        }

        GameObject bu = Instantiate(bullet);
        bu.GetComponent<Bullet>().Shoot(direction);
        Destroy(bu, 3.5f);
    }
}
