using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    protected float value;

    void Awake()
    {
        value = itemData.value;
    }

    public virtual void Use(PlayerSetting ps)
    {
        Destroy(gameObject);
    }
}
