using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Module_Move))]
[RequireComponent(typeof(Module_Attack))]
[RequireComponent(typeof(Module_Anim))]
public class Entity : MonoBehaviour
{
    protected Module_Move moveModule;
    protected Module_Attack attackModule;
    protected Module_Anim animModule;

    void Awake()
    {
        moveModule = GetComponent<Module_Move>();
        attackModule = GetComponent<Module_Attack>();
        animModule = GetComponent<Module_Anim>();
    }

    void Update()
    {
        SetAnim();
    }

    // 체력
    public float HP { get; set; }

    // 체력 깍이는 메서드
    public void UpdateHP(float v_HP)
    {
        HP += v_HP;
    }

    Vector2 currDirection;
    public void SetAnim()
    {
        if (animModule != null)
        {
            currDirection = moveModule.SMD.Direction;

            // 여기에 죽음 모션 체크하도록 구현

            animModule.SetMoveAnimation("MoveInput", currDirection);
        }
    }
}
