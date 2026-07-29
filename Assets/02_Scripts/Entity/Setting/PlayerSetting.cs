using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [SerializeField] Status status;
    [SerializeField] List<Item> canGetItems;
    public Entity PlayerEntity { get; set; }
    private float exp;
    private int level = 1;

    void Awake()
    {
        PlayerEntity = GetComponent<Entity>();
        PlayerEntity.HP = status.HP;
        GetComponent<Module_Move>().MoveSpeed = status.Speed;
    }

    void Update()
    {
        if (PlayerEntity.IsDied)
        {
            GameManager.Instance.OnGameOver.Invoke();
        }
    }

    // 스킬북

    // 아이템 만들기
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (collision.gameObject.GetComponent<Item>() is Item item)
                item.Use(this);
        }
    }

    public void UpdateEXP(float value)
    {
        exp += value;

        if (exp >= 100)
        {
            level++;
            exp -= 100;
        }
    }
}
