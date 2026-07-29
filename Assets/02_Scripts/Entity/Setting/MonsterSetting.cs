using UnityEngine;

public class MonsterSetting : MonoBehaviour
{
    [SerializeField] AttackElement ae;

    void Awake()
    {
        GetComponent<Module_Attack>().AddAttackElement(ae);
    }
}
