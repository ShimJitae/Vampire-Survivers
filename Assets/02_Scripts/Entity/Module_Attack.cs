using System.Collections.Generic;
using UnityEngine;

public class Module_Attack : MonoBehaviour
{
    private List<AttackElement> aes;

    void Awake()
    {
        // 캐릭터가 죽으면 공격 Element를 모두 끄도록.
        GetComponent<Entity>().OnDied += () =>
        {
            foreach (AttackElement ae in aes)
            {
                ae.ActiveHitArea(false);
            }
        };

        // 캐릭터가 살아나면 공격 Element를 모두 켜도록.
        GetComponent<Entity>().OnCreated += () =>
        {
            foreach (AttackElement ae in aes)
            {
                ae.ActiveHitArea(true);
            }
        };
    }

    public void AddAttackElement(AttackElement ae)
    {
        aes.Add(ae);
    }
}

public enum AttackTarget
{
    Monster,
    Player,
}
