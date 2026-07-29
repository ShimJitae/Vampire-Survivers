using UnityEngine;

public class Potion : Item
{
    [SerializeField] float healValue = 10;
    public override void Use(PlayerSetting ps)
    {
        ps.PlayerEntity.UpdateHP(healValue);
        Debug.Log($"potion {healValue}");
        base.Use(ps);
    }
}
