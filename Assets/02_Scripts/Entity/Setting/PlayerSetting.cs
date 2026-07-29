using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [SerializeField] Status status;

    void Awake()
    {
        GetComponent<Entity>().HP = status.HP;
        GetComponent<Module_Move>().MoveSpeed = status.Speed;
    }

    // 스킬북

    // 아이템 획득
}
