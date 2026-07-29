using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 direction;

    public void Shoot(Vector3 position, Vector2 _direction)
    {
        transform.position = position;
        direction = _direction;
    }

    float moveSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if (direction == Vector2.zero)
            return;

        transform.position += ((Vector3)direction + (Vector3)transform.right.normalized) * moveSpeed * Time.deltaTime;
    }
}
