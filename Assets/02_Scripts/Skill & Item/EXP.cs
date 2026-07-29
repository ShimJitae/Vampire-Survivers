using UnityEngine;

public class EXP : Item
{
    [SerializeField] float expValue = 20;
    public override void Use(PlayerSetting ps)
    {
        ps.UpdateEXP(expValue);
        Debug.Log($"exc {expValue}");
        base.Use(ps);
    }
}
