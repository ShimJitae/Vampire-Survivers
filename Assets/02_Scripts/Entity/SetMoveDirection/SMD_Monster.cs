using UnityEngine;

public class SMD_Monster : MonoBehaviour, ISetMoveDirection
{
    [SerializeField] private Transform player_T;

    void Awake()
    {
        if (player_T == null)
        {
            player_T = GameObject.FindWithTag("Player").transform;
        }
    }

    public Vector2 Direction { get; set; }

    void Update()
    {
        SetDirection();
    }

    public void SetDirection()
    {
        Direction = (player_T.position - transform.position).normalized;
    }
}
