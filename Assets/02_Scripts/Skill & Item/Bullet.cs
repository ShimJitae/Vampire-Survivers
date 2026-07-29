using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 direction;

    public void Shoot(Vector2 _direction)
    {
        direction = _direction;
    }

    float moveSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if (direction == Vector2.zero)
            return;

        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }
}
