using UnityEngine;

public class EXP : Item
{
    public override void Use(PlayerSetting ps)
    {
        ps.UpdateEXP(value);
        Debug.Log($"exc {value}");
        base.Use(ps);
    }
}
