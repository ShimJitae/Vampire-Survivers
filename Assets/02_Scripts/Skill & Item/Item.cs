using UnityEngine;

public class Item : MonoBehaviour
{
    public virtual void Use(PlayerSetting ps)
    {
        Destroy(gameObject);
    }
}
