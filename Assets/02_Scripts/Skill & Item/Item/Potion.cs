using UnityEngine;

public class Potion : Item
{
    public override void Use(PlayerSetting ps)
    {
        ps.PlayerEntity.UpdateHP(value);
        Debug.Log($"potion {value}");
        base.Use(ps);
    }
}
