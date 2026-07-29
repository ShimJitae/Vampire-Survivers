using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [SerializeField] Status status;
    Entity playerEntity;

    void Awake()
    {
        playerEntity = GetComponent<Entity>();
        playerEntity.HP = status.HP;
        GetComponent<Module_Move>().MoveSpeed = status.Speed;
    }

    void Update()
    {
        if (playerEntity.IsDied)
        {
            GameManager.Instance.OnGameOver.Invoke();
        }
    }

    // 스킬북

    // 아이템 획득
}
