using UnityEngine;

public class SMD_Player : MonoBehaviour, ISetMoveDirection
{
    public Vector2 Direction { get; set; }

    void Update()
    {
        SetDirection();
    }

    public void SetDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Direction = new Vector2(x, y).normalized;
    }
}
