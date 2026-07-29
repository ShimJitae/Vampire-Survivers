using UnityEngine;

public class Module_Move : MonoBehaviour
{
    // 일단 이렇게 넣고 나중에 moster spawner에서 smd 지정해주는걸로
    public ISetMoveDirection SMD { get; set; }

    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;

    void Awake()
    {
        SMD = GetComponent<ISetMoveDirection>();

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (SMD == null)
            return;

        rb.linearVelocity = SMD.Direction.normalized * moveSpeed;
    }
}
