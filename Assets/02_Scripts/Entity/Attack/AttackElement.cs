using System.Collections.Generic;
using UnityEngine;

public class AttackElement : MonoBehaviour
{
    public float Damage { get; set; }

    private Collider2D hitArea;
    [SerializeField] private AttackTarget target;

    void Awake()
    {
        hitArea = GetComponent<Collider2D>();
    }

    public void ActiveHitArea(bool isActive)
    {
        hitArea.enabled = isActive;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target.ToString()))
        {
            Entity entity = collision.GetComponent<Entity>();
            entity.UpdateHP(Damage);
        }
    }
}
