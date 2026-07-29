using UnityEngine;
using System;

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

        OnDied += () =>
        {
            IsDied = true;
            moveModule.enabled = false;
        };

        OnCreated += () =>
        {
            IsDied = false;
            moveModule.enabled = true;
        };
    }

    void Update()
    {
        SetAnim();
    }

    // 체력
    public float HP { get; set; }
    public event Action OnCreated;
    public event Action OnDied;
    public bool IsDied { get; set; }

    void OnEnable()
    {
        OnCreated?.Invoke();
    }

    // 체력 깍이는 메서드
    public void UpdateHP(float v_HP)
    {
        HP += v_HP;

        if (HP <= 0 && !IsDied)
        {
            HP = 0;
            OnDied?.Invoke();
        }
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
