using UnityEngine;

public class EXP : Item
{
    public override void Use(PlayerSetting ps)
    {
        ps.UpdateEXP(20);
    }
}
