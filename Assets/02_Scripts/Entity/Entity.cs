using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Module_Move))]
[RequireComponent(typeof(Module_Attack))]
public class Entity : MonoBehaviour
{
    protected Module_Move moveModule;
    protected Module_Attack attackModule;


    void Awake()
    {
        moveModule = GetComponent<Module_Move>();
        attackModule = GetComponent<Module_Attack>();
    }

    // 체력
    public float HP { get; set; }

    // 체력 깍이는 메서드
    public void UpdateHP(float v_HP)
    {
        HP += v_HP;
    }

    public void Attack()
    {
        //
    }
}
